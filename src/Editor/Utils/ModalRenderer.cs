using ImGuiNET;
using System.Numerics;

namespace NST
{
    public static class ModalRenderer
    {
        private sealed record ModalData(string Title, string? Text, List<ModalButton> Buttons, Action? RenderCallback = null);
        private sealed record ModalButton(string Text, Action? Callback = null);

        private static ModalData? _current = null;
        private static ModalData? _last = null;

        private static bool _requestOpen = false;
        private static bool _isLoading = false;

        private const string loadingTitle = "In progress...";

        private static void Open(string title, string? text, List<ModalButton> buttons, Action? renderCallback = null, bool open = true)
        {
            _last = _current;
            _current = new ModalData(title, text, buttons, renderCallback);
            _requestOpen = open;
        }

        private static void Close(ModalData? modal, bool closeCurrentPopup = true)
        {
            if (_current != modal) return;

            _current = null;
            _requestOpen = false;

            if (closeCurrentPopup)
                ImGui.CloseCurrentPopup();
        }

        public static void Restore()
        {
            if (_last == null || !_isLoading) return;
            Open(_last.Title, _last.Text, _last.Buttons, _last.RenderCallback);
        }

        public static void Render()
        {
            ModalData? modal = _current;
            if (modal == null) return;

            string popupId = $"{modal.Title}###PopupModal";

            if (_requestOpen)
            {
                var center = ImGui.GetMainViewport().GetCenter();
                ImGui.SetNextWindowPos(center, ImGuiCond.Always, new Vector2(0.5f, 0.5f));
                ImGui.OpenPopup(popupId);
                _requestOpen = false;
            }

            if (!ImGui.BeginPopupModal(popupId, ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoSavedSettings))
            {
                Close(modal, false);
                return;
            }

            RenderContent(modal);

            ImGui.EndPopup();
        }

        private static void RenderContent(ModalData modal)
        {
            if (!string.IsNullOrEmpty(modal.Text))
            {
                if (modal.Buttons.Count >= 3)
                {
                    ImGui.PushTextWrapPos(ImGui.GetFontSize() * 40);
                    ImGui.TextWrapped(modal.Text);
                    ImGui.PopTextWrapPos();
                    ImGuiUtils.VerticalSpacing(10);
                }
                else
                {
                    ImGui.Text(modal.Text);
                    ImGui.Spacing();
                }
            }

            modal.RenderCallback?.Invoke();

            for (int i = 0; i < modal.Buttons.Count; i++)
            {
                var btn = modal.Buttons[i];

                if (i > 0)
                    ImGui.SameLine();

                if (ImGui.Button(btn.Text, ComputeButtonSize(modal.Buttons.Count)))
                {
                    Close(modal);
                    btn.Callback?.Invoke();
                    break;
                }
            }
        }

        private static Vector2 ComputeButtonSize(int count)
        {
            float availWidth = ImGui.GetContentRegionAvail().X;
            Vector2 buttonSize = new Vector2(float.Max(availWidth * 0.2f, 100), 0);
            float newX = ImGui.GetCursorPosX() + availWidth - buttonSize.X * count - ImGui.GetStyle().ItemSpacing.X * (count - 1);
            if (newX > ImGui.GetCursorPosX()) ImGui.SetCursorPosX(newX);
            return buttonSize;
        }

        /// <summary>
        /// Show a modal with 1 button
        /// </summary>
        public static void Show(string title, string message, Action? action = null)
        {
            Open(title, message, [ new ModalButton("OK", action) ]);
        }

        /// <summary>
        /// Show a modal with 2 buttons
        /// </summary>
        public static void ShowModal2(string title, string message, Action confirmAction, string cancelTitle = "No", string confirmTitle = "Yes")
        {
            ShowModal2(title, message, null, confirmAction, cancelTitle, confirmTitle);
        }

        public static void ShowModal2(string title, string message, Action? cancelAction, Action? confirmAction, string cancelTitle = "No", string confirmTitle = "Yes")
        {
            Open(title, message, 
            [ 
                new ModalButton(cancelTitle, cancelAction),
                new ModalButton(confirmTitle, confirmAction),
            ]);
        }

        /// <summary>
        /// Show a modal with 3 buttons
        /// </summary>
        public static void ShowModal3(string title, string message, Action onSafeAction, Action onContinue, string onSafeTitle = "No", string onContinueTitle = "Yes")
        {
            Open(title, message, 
            [ 
                new ModalButton("Cancel"),
                new ModalButton(onSafeTitle, onSafeAction),
                new ModalButton(onContinueTitle, onContinue)
            ]);
        }

        /// <summary>
        /// Show a rename modal
        /// </summary>
        public static void ShowRenameModal(string fileName, Action<string> action)
        {
            Open("Rename file", null,
            [
                new ModalButton("Cancel"),
                new ModalButton("OK", () => action.Invoke(fileName)),
            ], 
            () =>
            {
                ImGui.Text("Select a new file name:");
                ImGui.Spacing();

                float textWidth = ImGui.CalcTextSize(fileName).X + ImGui.GetStyle().FramePadding.X * 2;

                ImGui.SetNextItemWidth(textWidth);
                ImGui.InputText("##RenameModalInput", ref fileName, 256);
                ImGui.Spacing();
            });
        }

        /// <summary>
        /// Show a modal with a progress bar
        /// </summary>
        public static void ShowLoadingModal(string message, float? progress = null)
        {
            _isLoading = true;

            Open(loadingTitle, null, [], () =>
            {
                float p = progress ?? (-1.0f * (float)ImGui.GetTime());
                ImGui.ProgressBar(p, new Vector2(400, 15) * SilkWindow.instance.scale, message); 
            }, 
            open: _current?.Title != loadingTitle);
        }

        public static void CloseLoadingModal()
        {
            _isLoading = false;

            if (_current?.Title == loadingTitle)
                Close(_current);
        }
    }
}