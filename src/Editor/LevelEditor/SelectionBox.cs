using THREE;
using ImGuiNET;
using NST;

public class SelectionBox 
{
	public Action OnSelect;

    public Vector2 PointTopLeft { get; }= new Vector2();
    public Vector2 PointBottomRight { get; } = new Vector2();

    private Frustum _frustum = new Frustum();
    private Vector3 _center = new Vector3();

    private Vector3 _tmpPoint = new Vector3();

    private Vector3 _vecNear = new Vector3();
    private Vector3 _vecTopLeft = new Vector3();
    private Vector3 _vecTopRight = new Vector3();
    private Vector3 _vecDownRight = new Vector3();
    private Vector3 _vecDownLeft = new Vector3();

    private Vector3 _vectemp1 = new Vector3();
    private Vector3 _vectemp2 = new Vector3();
    private Vector3 _vectemp3 = new Vector3();

    private Matrix4 _matrix = new Matrix4();
    private Quaternion _quaternion = new Quaternion();
    private Vector3 _scale = new Vector3();

    private Object3D root;
    private Camera camera;
    private Vector3 startPoint = new Vector3();
    private Vector3 endPoint = new Vector3();
    private HashSet<NSTObject> selection = [];
    private float deep = 0;

    private bool isDown = false;
	private bool isDragging = false;
    private Vector2 _startPoint = new Vector2();

	public SelectionBox( LevelExplorer explorer, Camera camera, Object3D root, float deep = float.MaxValue ) 
	{
		this.camera = camera;
		this.root = root;
		this.deep = deep;

		startPoint = new Vector3();
		endPoint = new Vector3();

        explorer.MouseDown += (sender, args) =>
        {
			if (args.Button != Silk.NET.Input.MouseButton.Left) return;
			if (!explorer.IsWindowFocused) return;

            _startPoint.Set(args.X, args.Y);
			PointBottomRight.Set(0,0);
			PointTopLeft.Set(0,0);

            isDown = true;
			isDragging = false;
        };

        explorer.MouseMove += (sender, args) =>
        {
			if (args.Button != Silk.NET.Input.MouseButton.Left) return;
			if (!explorer.CanUseBoxSelection) return;
            if (!isDown) return;

            PointBottomRight.X = Math.Max( _startPoint.X, args.X );
            PointBottomRight.Y = Math.Max( _startPoint.Y, args.Y );
            PointTopLeft.X = Math.Min( _startPoint.X, args.X );
            PointTopLeft.Y = Math.Min( _startPoint.Y, args.Y );

			isDragging = true;
        };

        explorer.MouseUp += (sender, args) =>
        {
			if (args.Button != Silk.NET.Input.MouseButton.Left) return;

			if (isDown && isDragging)
			{
				OnSelect?.Invoke();
			}

            isDown = false;
			isDragging = false;
        };
	}

    public void Draw()
    {
        if (!isDragging) return;

        var min = new System.Numerics.Vector2(PointBottomRight.X, PointBottomRight.Y);
        var max = new System.Numerics.Vector2(PointTopLeft.X, PointTopLeft.Y);

        var drawList = ImGui.GetForegroundDrawList();

        drawList.AddRectFilled(min, max, ImGui.GetColorU32(new System.Numerics.Vector4(0f, 0.5f, 1f, 0.15f))); // Filled rectangle
        drawList.AddRect(min, max, ImGui.GetColorU32(new System.Numerics.Vector4(0f, 0.5f, 1f, 0.8f)), 0f, ImDrawFlags.None, 2f); // Border
    }

	public HashSet<NSTObject> Select( Vector3? startPoint = null, Vector3? endPoint = null ) 
	{
		this.startPoint = startPoint ?? this.startPoint;
		this.endPoint = endPoint ?? this.endPoint;
        this.selection = [];

		UpdateFrustum( this.startPoint, this.endPoint );
		SearchChildInFrustum( _frustum, this.root );

		return this.selection;
	}

	private void UpdateFrustum( Vector3? startPoint, Vector3? endPoint ) 
	{
		startPoint = startPoint ?? this.startPoint;
		endPoint = endPoint ?? this.endPoint;

		// Avoid invalid frustum

		if ( startPoint.X == endPoint.X ) 
		{
			endPoint.X += 1e-3f;
		}

		if ( startPoint.Y == endPoint.Y ) 
		{
			endPoint.Y += 1e-3f;
		}

		this.camera.UpdateProjectionMatrix();
		this.camera.UpdateMatrixWorld();

		// if ( this.camera.isPerspectiveCamera )

		_tmpPoint.Copy( startPoint );
		_tmpPoint.X = Math.Min( startPoint.X, endPoint.X );
		_tmpPoint.Y = Math.Max( startPoint.Y, endPoint.Y );
		endPoint.X = Math.Max( startPoint.X, endPoint.X );
		endPoint.Y = Math.Min( startPoint.Y, endPoint.Y );

		_vecNear.SetFromMatrixPosition( this.camera.MatrixWorld );
		_vecTopLeft.Copy( _tmpPoint );
		_vecTopRight.Set( endPoint.X, _tmpPoint.Y, 0 );
		_vecDownRight.Copy( endPoint );
		_vecDownLeft.Set( _tmpPoint.X, endPoint.Y, 0 );

		_vecTopLeft.UnProject( this.camera );
		_vecTopRight.UnProject( this.camera );
		_vecDownRight.UnProject( this.camera );
		_vecDownLeft.UnProject( this.camera );

		_vectemp1.Copy( _vecTopLeft ).Sub( _vecNear );
		_vectemp2.Copy( _vecTopRight ).Sub( _vecNear );
		_vectemp3.Copy( _vecDownRight ).Sub( _vecNear );
		_vectemp1.Normalize();
		_vectemp2.Normalize();
		_vectemp3.Normalize();

		_vectemp1.MultiplyScalar( this.deep );
		_vectemp2.MultiplyScalar( this.deep );
		_vectemp3.MultiplyScalar( this.deep );
		_vectemp1.Add( _vecNear );
		_vectemp2.Add( _vecNear );
		_vectemp3.Add( _vecNear );

		var planes = _frustum.Planes;

		planes[ 0 ].SetFromCoplanarPoints( _vecNear, _vecTopLeft, _vecTopRight );
		planes[ 1 ].SetFromCoplanarPoints( _vecNear, _vecTopRight, _vecDownRight );
		planes[ 2 ].SetFromCoplanarPoints( _vecDownRight, _vecDownLeft, _vecNear );
		planes[ 3 ].SetFromCoplanarPoints( _vecDownLeft, _vecTopLeft, _vecNear );
		planes[ 4 ].SetFromCoplanarPoints( _vecTopRight, _vecDownRight, _vecDownLeft );
		planes[ 5 ].SetFromCoplanarPoints( _vectemp3, _vectemp2, _vectemp1 );
		planes[ 5 ].Normal.MultiplyScalar( - 1 );
	}

	private void SearchChildInFrustum( Frustum frustum, Object3D obj ) 
	{
		if ( obj is Mesh || obj is Line || obj is Points ) 
		{
			if (!obj.Layers.Test(camera.Layers)) return;

			if ( obj is InstancedMesh instanced && instanced.UserData.TryGetValue("instance", out object? value)) 
			{
                InstanceManager instanceManager = (InstanceManager)value;

				List<NSTEntity>? entities = null;

				for ( int instanceId = 0; instanceId < instanced.InstanceCount; instanceId ++ ) 
				{
					instanced.GetMatrixAt( instanceId, _matrix );
					_matrix.Decompose( _center, _quaternion, _scale );
					_center.ApplyMatrix4( obj.MatrixWorld );

					if ( frustum.ContainsPoint( _center ) ) 
					{
						entities ??= instanceManager.Entities.Where(e => !e.IsSelected).ToList();

                        selection.Add(entities[instanceId]);
					}
				}
			} 
			else if (obj.Geometry != null) 
			{
				if ( obj.Geometry.BoundingSphere == null ) obj.Geometry.ComputeBoundingSphere();

				_center.Copy( obj.Geometry.BoundingSphere!.Center );

				_center.ApplyMatrix4( obj.MatrixWorld );

				if ( frustum.ContainsPoint( _center ) ) 
				{
                    if (obj.UserData.TryGetValue("entity", out object? entityValue))
                    {
                        selection.Add((NSTObject)entityValue);    
                    }
				}
			}
		}

		if ( obj.Children.Count > 0 ) 
		{
			for ( int x = 0; x < obj.Children.Count; x ++ ) 
			{
				this.SearchChildInFrustum( frustum, obj.Children[ x ] );
			}
		}
	}
}