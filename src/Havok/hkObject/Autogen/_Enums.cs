namespace Havok
{
    public enum EVariableMode : i8
    {
        VARIABLE_MODE_DISCARD_WHEN_INACTIVE = 0,
        VARIABLE_MODE_MAINTAIN_VALUES_WHEN_INACTIVE = 1,
    }

    public enum EStartStateMode : i8
    {
        START_STATE_MODE_DEFAULT = 0,
        START_STATE_MODE_SYNC = 1,
        START_STATE_MODE_RANDOM = 2,
        START_STATE_MODE_CHOOSER = 3,
    }

    public enum EStateMachineSelfTransitionMode : i8
    {
        SELF_TRANSITION_MODE_NO_TRANSITION = 0,
        SELF_TRANSITION_MODE_TRANSITION_TO_START_STATE = 1,
        SELF_TRANSITION_MODE_FORCE_TRANSITION_TO_START_STATE = 2,
    }

    public enum EInitialVelocityCoordinates : i8
    {
        INITIAL_VELOCITY_IN_WORLD_COORDINATES = 0,
        INITIAL_VELOCITY_IN_MODEL_COORDINATES = 1,
    }

    public enum EMotionMode : i8
    {
        MOTION_MODE_FOLLOW_ANIMATION = 0,
        MOTION_MODE_DYNAMIC = 1,
    }

    public enum EEndMode : i8
    {
        END_MODE_NONE = 0,
        END_MODE_TRANSITION_UNTIL_END_OF_FROM_GENERATOR = 1,
        END_MODE_CAP_DURATION_AT_END_OF_FROM_GENERATOR = 2,
    }

    public enum EBlendCurve : i8
    {
        BLEND_CURVE_SMOOTH = 0,
        BLEND_CURVE_LINEAR = 1,
        BLEND_CURVE_LINEAR_TO_SMOOTH = 2,
        BLEND_CURVE_SMOOTH_TO_LINEAR = 3,
    }

    public enum EPlaybackMode : i8
    {
        MODE_SINGLE_PLAY = 0,
        MODE_LOOPING = 1,
        MODE_USER_CONTROLLED = 2,
        MODE_PING_PONG = 3,
        MODE_COUNT = 4,
    }

    public enum EBlendType : i8
    {
        BLEND_TYPE_BLEND_IN = 0,
        BLEND_TYPE_FULL_ON = 1,
    }

    public enum EEventMode : i8
    {
        EVENT_MODE_DEFAULT = 0,
        EVENT_MODE_PROCESS_ALL = 1,
        EVENT_MODE_IGNORE_FROM_GENERATOR = 2,
        EVENT_MODE_IGNORE_TO_GENERATOR = 3,
    }

    public enum ESetAngleMethod : i8
    {
        LINEAR = 0,
        RAMPED = 1,
    }

    public enum ERotationAxisCoordinates : i8
    {
        ROTATION_AXIS_IN_MODEL_COORDINATES = 0,
        ROTATION_AXIS_IN_PARENT_COORDINATES = 1,
        ROTATION_AXIS_IN_LOCAL_COORDINATES = 2,
    }

    public enum EAnimationType : i32
    {
        HK_UNKNOWN_ANIMATION = 0,
        HK_INTERLEAVED_ANIMATION = 1,
        HK_MIRRORED_ANIMATION = 2,
        HK_SPLINE_COMPRESSED_ANIMATION = 3,
        HK_QUANTIZED_COMPRESSED_ANIMATION = 4,
        HK_PREDICTIVE_COMPRESSED_ANIMATION = 5,
        HK_REFERENCE_POSE_ANIMATION = 6,
    }

    public enum EBlendHint : i8
    {
        NORMAL = 0,
        ADDITIVE_DEPRECATED = 1,
        ADDITIVE = 2,
    }

    public enum ESelfTransitionMode : i8
    {
        SELF_TRANSITION_MODE_CONTINUE_IF_CYCLIC_BLEND_IF_ACYCLIC = 0,
        SELF_TRANSITION_MODE_CONTINUE = 1,
        SELF_TRANSITION_MODE_RESET = 2,
        SELF_TRANSITION_MODE_BLEND = 3,
    }

    public enum EVariableType : i8
    {
        VARIABLE_TYPE_INVALID = -1,
        VARIABLE_TYPE_BOOL = 0,
        VARIABLE_TYPE_INT8 = 1,
        VARIABLE_TYPE_INT16 = 2,
        VARIABLE_TYPE_INT32 = 3,
        VARIABLE_TYPE_REAL = 4,
        VARIABLE_TYPE_POINTER = 5,
        VARIABLE_TYPE_VECTOR3 = 6,
        VARIABLE_TYPE_VECTOR4 = 7,
        VARIABLE_TYPE_QUATERNION = 8,
    }

    public enum EEnum : u8
    {
        CONVEX = 0,
        CONVEX_POLYTOPE = 1,
        SPHERE = 2,
        CAPSULE = 3,
        TRIANGLE = 4,
        COMPRESSED_MESH = 5,
        EXTERN_MESH = 6,
        STATIC_COMPOUND = 7,
        DYNAMIC_COMPOUND = 8,
        HEIGHT_FIELD = 9,
        COMPRESSED_HEIGHT_FIELD = 10,
        SCALED_CONVEX = 11,
        MASKED = 12,
        MASKED_COMPOUND = 13,
        LOD = 14,
        DUMMY = 15,
        USER_0 = 16,
        USER_1 = 17,
        USER_2 = 18,
        USER_3 = 19,
        NUM_SHAPE_TYPES = 20,
        INVALID = 21,
    }

    public enum ETriggerType : u8
    {
        TRIGGER_TYPE_NONE = 0,
        TRIGGER_TYPE_BROAD_PHASE = 1,
        TRIGGER_TYPE_NARROW_PHASE = 2,
        TRIGGER_TYPE_CONTACT_SOLVER = 3,
    }

    public enum ECombinePolicy : u8
    {
        COMBINE_AVG = 0,
        COMBINE_MIN = 1,
        COMBINE_MAX = 2,
    }

    public enum EMassChangerCategory : u8
    {
        MASS_CHANGER_IGNORE = 0,
        MASS_CHANGER_DEBRIS = 1,
        MASS_CHANGER_HEAVY = 2,
    }

    public enum ESimulationType : u8
    {
        SIMULATION_TYPE_SINGLE_THREADED = 0,
        SIMULATION_TYPE_MULTI_THREADED = 1,
    }

    public enum ELeavingBroadPhaseBehavior : u8
    {
        ON_LEAVING_BROAD_PHASE_DO_NOTHING = 0,
        ON_LEAVING_BROAD_PHASE_REMOVE_BODY = 1,
        ON_LEAVING_BROAD_PHASE_FREEZE_BODY = 2,
    }

    public enum EType : i8
    {
        UNKNOWN = -1,
        INVALID = 0,
        TRIANGLE = 1,
        QUAD = 2,
        CUSTOM = 3,
        NUM_TYPES = 4,
    }

    public enum ERole : i16
    {
        ROLE_DEFAULT = 0,
        ROLE_FILE_NAME = 1,
        ROLE_BONE_INDEX = 2,
        ROLE_EVENT_ID = 3,
        ROLE_VARIABLE_INDEX = 4,
        ROLE_ATTRIBUTE_INDEX = 5,
        ROLE_TIME = 6,
        ROLE_SCRIPT = 7,
        ROLE_LOCAL_FRAME = 8,
        ROLE_BONE_ATTACHMENT = 9,
    }

    public enum EIndexType : i8
    {
        INDEX_TYPE_INVALID = 0,
        INDEX_TYPE_TRI_LIST = 1,
        INDEX_TYPE_TRI_STRIP = 2,
        INDEX_TYPE_TRI_FAN = 3,
        INDEX_TYPE_MAX_ID = 4,
    }

    public enum EUVMappingAlgorithm : u32
    {
        UVMA_SRT = 0,
        UVMA_TRS = 1,
        UVMA_3DSMAX_STYLE = 2,
        UVMA_MAYA_STYLE = 3,
    }

    public enum ETransparency : u8
    {
        transp_none = 0,
        transp_alpha = 2,
        transp_additive = 3,
        transp_colorkey = 4,
        transp_subtractive = 9,
    }

    public enum EBindingType : i8
    {
        BINDING_TYPE_VARIABLE = 0,
        BINDING_TYPE_CHARACTER_PROPERTY = 1,
    }

    public enum ETextureType : i32
    {
        TEX_UNKNOWN = 0,
        TEX_DIFFUSE = 1,
        TEX_REFLECTION = 2,
        TEX_BUMP = 3,
        TEX_NORMAL = 4,
        TEX_DISPLACEMENT = 5,
        TEX_SPECULAR = 6,
        TEX_SPECULARANDGLOSS = 7,
        TEX_OPACITY = 8,
        TEX_EMISSIVE = 9,
        TEX_REFRACTION = 10,
        TEX_GLOSS = 11,
        TEX_DOMINANTS = 12,
        TEX_NOTEXPORTED = 13,
    }

    public enum EDataUsage : u16
    {
        HKX_DU_NONE = 0,
        HKX_DU_POSITION = 1,
        HKX_DU_COLOR = 2,
        HKX_DU_NORMAL = 4,
        HKX_DU_TANGENT = 8,
        HKX_DU_BINORMAL = 16,
        HKX_DU_TEXCOORD = 32,
        HKX_DU_BLENDWEIGHTS = 64,
        HKX_DU_BLENDINDICES = 128,
        HKX_DU_USERDATA = 256,
    }

    public enum EDataType : u16
    {
        HKX_DT_NONE = 0,
        HKX_DT_UINT8 = 1,
        HKX_DT_INT16 = 2,
        HKX_DT_UINT32 = 3,
        HKX_DT_FLOAT = 4,
    }

}