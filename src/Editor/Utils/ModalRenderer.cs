using ImGuiNET;
using System.Numerics;

namespace NST
{
    /// <summary>
    /// Interface for modal windows
    /// </summary>
    public interface IModalBase
    {
        public bool IsOpen();
        public bool Render();
    }
    
    /// <summary>
    /// Base class for modal windows
    /// </summary>
    public class ModalBase<TAction> : IModalBase where TAction : Delegate
    {
        private string _identifier; // Modal unique identifier
        protected string _name = ""; // Modal title
        protected TAction? _callback; // Confirm callback
        protected bool _isOpen; // Whether the modal is currently visible

        public bool IsOpen() => _isOpen;

        public ModalBase(string identifier) => _identifier = identifier;

        /// <summary>
        /// Show the modal
        /// </summary>
        public void Open(string name, TAction? callback)
        {
            _name = name;
            _callback = callback;
            _isOpen = true;
        }

        /// <summary>
        /// Close the modal and invoke the confirm callback
        /// </summary>
        protected void OnClickOK(params object[] args)
        {
            _isOpen = false;
            _callback?.DynamicInvoke(args);
            ImGui.CloseCurrentPopup();
        }

        /// <summary>
        /// Close the modal
        /// </summary>
        protected void OnClickCancel()
        {
            _isOpen = false;
            ImGui.CloseCurrentPopup();
        }

        /// <summary>
        /// Get the size of each button based on the number of buttons
        /// </summary>
        protected static Vector2 ComputeButtonSize(int count = 1)
        {
            float availWidth = ImGui.GetContentRegionAvail().X;
            Vector2 buttonSize = new Vector2(float.Max(availWidth * 0.2f, 100), 0);
            float newX = ImGui.GetCursorPosX() + availWidth - buttonSize.X * count - ImGui.GetStyle().ItemSpacing.X * (count - 1);
            if (newX > ImGui.GetCursorPosX()) ImGui.SetCursorPosX(newX);
            return buttonSize;
        }

        /// <summary>
        /// Render the modal
        /// </summary>
        /// <returns>Whether the modal is currently open</returns>
        public virtual bool Render()
        {
            if (_isOpen)
            {
                ImGui.OpenPopup(_identifier);
            }

            ImGui.BeginPopupModal(_identifier, ImGuiWindowFlags.AlwaysAutoResize);

            return _isOpen;
        }
    }

    /// <summary>
    /// Modal for displaying a message (OK button)
    /// </summary>
    public class MessageModal() : ModalBase<Action>("Message")
    {
        private string _message = "";

        public void Open(string title, string message, Action? action)
        {
            base.Open(title, action);
            _message = message;
        }

        public override bool Render()
        {
            if (!base.Render()) return false;

            ImGui.Text(_message);

            if (ImGui.Button("OK", ComputeButtonSize())) 
                OnClickOK();

            ImGui.EndPopup();

            return true;
        }
    }

    /// <summary>
    /// Modal for confirming an action (Confirm / Safe Choice / Cancel)
    /// </summary>
    public class ConfirmationModal() : ModalBase<Action>("Warning")
    {
        private Action? _safeCallback;

        private string _safeTitle = "Save as...";
        private string _continueTitle = "Overwrite";

        public void Open(string message, Action? onSafeAction, Action? onContinue, string? onSafeTitle, string? onContinueTitle)
        {
            base.Open(message, onContinue);
            _safeCallback = onSafeAction;
            _safeTitle = onSafeTitle ?? _safeTitle;
            _continueTitle = onContinueTitle ?? _continueTitle;
        }

        private void OnClickContinue()
        {
            _isOpen = false;
            _safeCallback?.DynamicInvoke();
            ImGui.CloseCurrentPopup();
        }

        public override bool Render()
        {
            if (!base.Render()) return false;

            ImGui.PushTextWrapPos(ImGui.GetFontSize() * 40);
            ImGui.TextWrapped(_name);
            ImGui.PopTextWrapPos();

            ImGuiUtils.VerticalSpacing(10);

            Vector2 buttonSize = ComputeButtonSize(3);

            if (ImGui.Button("Cancel", buttonSize)) OnClickCancel();
            ImGui.SameLine();

            if (ImGui.Button(_safeTitle, buttonSize)) OnClickContinue();
            ImGui.SameLine();

            if (ImGui.Button(_continueTitle, buttonSize)) OnClickOK();
            ImGui.EndPopup();

            return true;
        }
    }

    /// <summary>
    /// Modal for deleting a file (Yes / No)
    /// </summary>
    public class DeleteModal() : ModalBase<Action>("Delete File")
    {
        public override bool Render()
        {
            if (!base.Render()) return false;

            ImGui.Text("Are you sure you want to delete " + _name + "?");
            ImGui.Spacing();

            Vector2 buttonSize = ComputeButtonSize(2);

            if (ImGui.Button("No", buttonSize)) OnClickCancel();
            ImGui.SameLine();

            if (ImGui.Button("Yes", buttonSize)) OnClickOK();
            ImGui.EndPopup();

            return true;
        }
    }

    /// <summary>
    /// Modal for renaming a file (OK / Cancel)
    /// </summary>
    public class RenameModal() : ModalBase<Action<string>>("Rename File")
    {
        public override bool Render()
        {
            if (!base.Render()) return false;

            ImGui.Text("Select a new file name:");
            ImGui.Spacing();

            float textWidth = ImGui.CalcTextSize(_name).X + ImGui.GetStyle().FramePadding.X * 2;

            ImGui.SetNextItemWidth(textWidth);
            ImGui.InputText("##RenameInput", ref _name, 256);
            ImGui.Spacing();

            Vector2 buttonSize = ComputeButtonSize(2);

            if (ImGui.Button("Cancel", buttonSize)) OnClickCancel();
            ImGui.SameLine();

            if (ImGui.Button("OK", buttonSize)) OnClickOK(_name);
            ImGui.EndPopup();

            return true;
        }
    }

    /// <summary>
    /// Handles rendering of blocking modals/popups
    /// </summary>
    public class ModalRenderer
    {
        private static MessageModal _messageModal = new MessageModal();
        private static ConfirmationModal _confirmationModal = new ConfirmationModal();
        private static DeleteModal _deleteModal = new DeleteModal();
        private static RenameModal _renameModal = new RenameModal();
        private static List<IModalBase> _modals = [ _messageModal, _confirmationModal, _deleteModal, _renameModal ];

        /// <summary>
        /// Show a message modal (OK button)
        /// </summary>
        public static void ShowMessageModal(string title, string message, Action? action = null)
        {
            _messageModal.Open(title, message, action);
        }

        /// <summary>
        /// Show a confirmation modal (Confirm / Safe Choice / Cancel)
        /// </summary>
        public static void ShowConfirmationModal(string message, Action? onSafeAction, Action? onContinue, string? onSafeTitle = null, string? onContinueTitle = null)
        {
            _confirmationModal.Open(message, onSafeAction, onContinue, onSafeTitle, onContinueTitle);
        }

        /// <summary>
        /// Show a delete modal (Yes / No)
        /// </summary>
        public static void ShowDeleteModal(string fileName, Action action)
        {
            _deleteModal.Open(fileName, action);
        }

        /// <summary>
        /// Show a rename modal (OK / Cancel)
        /// </summary>
        public static void ShowRenameModal(string fileName, Action<string> action)
        {
            _renameModal.Open(fileName, action);
        }

        /// <summary>
        /// Render any open modals
        /// </summary>
        public static void RenderModals()
        {
            foreach (IModalBase modal in _modals)
            {
                if (modal.IsOpen())
                {
                    modal.Render();
                    break;
                }
            }
        }
    }
}