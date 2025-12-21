using Alchemy;
using ImGuiNET;
using System.Numerics;
using System.Diagnostics;

namespace NST
{
    /// <summary>
    /// Renders and manages which mods are currently loaded/active
    /// </summary>
    public class ModManager
    {
        // List of all levels in the game
        public static readonly string[] _levels = {
            "Main Menu",
            "crash1/l100_hub",
            "crash1/l101_nsanitybeach",
            "crash1/l102_junglerollers",
            "crash1/l103_thegreatgate",
            "crash1/l104_boulders",
            "crash1/l105_upstream",
            "crash1/l106_rollingstones",
            "crash1/l107_hogwild",
            "crash1/l108_nativefortress",
            "crash1/l109_upthecreek",
            "crash1/l110_thelostcity",
            "crash1/l111_templeruins",
            "crash1/l112_roadtonowhere",
            "crash1/l113_boulderdash",
            "crash1/l114_wholehog",
            "crash1/l115_sunsetvista",
            "crash1/l116_heavymachinery",
            "crash1/l117_cortexpower",
            "crash1/l118_generatorroom",
            "crash1/l119_toxicwaste",
            "crash1/l120_thehighroad",
            "crash1/l121_slipperyclimb",
            "crash1/l122_lightsout",
            "crash1/l123_fumblinginthedark",
            "crash1/l124_jawsofdarkness",
            "crash1/l125_castlemachinery",
            "crash1/l126_thelab",
            "crash1/l127_thegreathall",
            "crash1/l128_stormyascent",
            "crash2/l200_hub",
            "crash2/l200_intro",
            "crash2/l201_turtlewoods",
            "crash2/l202_snowgo",
            "crash2/l203_hangeight",
            "crash2/l204_thepits",
            "crash2/l205_crashdash",
            "crash2/l206_snowbiz",
            "crash2/l207_aircrash",
            "crash2/l208_bearit",
            "crash2/l209_crashcrush",
            "crash2/l210_theeeldeal",
            "crash2/l211_plantfood",
            "crash2/l212_sewerorlater",
            "crash2/l213_beardown",
            "crash2/l214_roadtoruin",
            "crash2/l215_unbearable",
            "crash2/l216_hanginout",
            "crash2/l217_digginit",
            "crash2/l218_coldhardcrash",
            "crash2/l219_ruination",
            "crash2/l220_beehaving",
            "crash2/l221_pistonitaway",
            "crash2/l222_rockit",
            "crash2/l223_nightfight",
            "crash2/l224_packattack",
            "crash2/l225_spacedout",
            "crash2/l226_totallybear",
            "crash2/l227_totallyfly",
            "crash3/l300_hub",
            "crash3/l301_toadvillage",
            "crash3/l302_underpressure",
            "crash3/l303_orientexpress",
            "crash3/l304_boneyard",
            "crash3/l305_makinwaves",
            "crash3/l306_geewiz",
            "crash3/l307_hangemhigh",
            "crash3/l308_hogride",
            "crash3/l309_tombtime",
            "crash3/l310_midnightrun",
            "crash3/l311_dinomight",
            "crash3/l312_deeptrouble",
            "crash3/l313_hightime",
            "crash3/l314_roadcrash",
            "crash3/l315_doubleheader",
            "crash3/l316_sphynxinator",
            "crash3/l317_byebyeblimps",
            "crash3/l318_tellnotales",
            "crash3/l319_futurefrenzy",
            "crash3/l320_tombwader",
            "crash3/l321_gonetomorrow",
            "crash3/l322_orangeasphalt",
            "crash3/l323_flamingpassion",
            "crash3/l324_madbombers",
            "crash3/l325_buglite",
            "crash3/l326_skicrazed",
            "crash3/l328_area51",
            "crash3/l330_ringsofpower",
            "crash3/l331_hotcoco",
            "crash3/l332_eggipusrex",
            "crash3/l333_futuretense",
            "crash1/bosses/b101_papupapu",
            "crash1/bosses/b102_ripperroo",
            "crash1/bosses/b103_koalakong",
            "crash1/bosses/b104_pinstripepotoroo",
            "crash1/bosses/b105_drnitrusbrio",
            "crash1/bosses/b106_drneocortex",
            "crash2/bosses/b201_ripperroo",
            "crash2/bosses/b202_komodobrothers",
            "crash2/bosses/b203_tinytiger",
            "crash2/bosses/b204_drngin",
            "crash2/bosses/b205_drneocortex",
            "crash3/bosses/b301_tinytiger",
            "crash3/bosses/b302_dingodile",
            "crash3/bosses/b303_ntropy",
            "crash3/bosses/b304_ngin",
            "crash3/bosses/b305_neocortex",
            "crash1/c1_intro",
            "crash1/c1_outro",
            "crash1/c1_outro100",
            "crash1/c1_startscreen",
            "crash2/c2_outro01",
            "crash2/c2_outro02",
            "crash3/c3_intro",
            "whiterooms/wr_c2_levelendtest",
            "whiterooms/wr_c3_levelendtest",
            "whiterooms/wr_crates/crash_crates"
        };

        private List<string> _modPaths = []; // Paths to mod files
        private HashSet<string> _enabledMods = []; // List of enabled mods
        private HashSet<string> _missingMods = []; // List of mods that are missing

        private bool _isGameModded = false;

        private int _selectedLevel = 0;

        private static long _lastLaunchGameClick = 0;
        public static bool CanClickPlay => (DateTime.Now.Ticks - _lastLaunchGameClick) / TimeSpan.TicksPerMillisecond > 3000;
        public static void PlayButtonTimeout() => _lastLaunchGameClick = DateTime.Now.Ticks;

        /// <summary>
        /// Initialize the mod manager
        /// </summary>
        public void Initialize()
        {
            // Load mod list
            _modPaths = LocalStorage.Get<List<string>>("mod_paths") ?? [];
            _enabledMods = LocalStorage.Get<HashSet<string>>("enabled_mods") ?? [];

            // Check for missing mod files
            foreach (string path in _modPaths)
            {
                if (!File.Exists(path))
                {
                    _missingMods.Add(path);

                    if  (_enabledMods.Contains(path)) 
                        _enabledMods.Remove(path);
                }
            }

            // Check if game is modded
            _isGameModded = CheckIsGameModded();

            // Load last selected level
            _selectedLevel = LocalStorage.Get("selected_level", 0);
        }

        /// <summary>
        /// Returns true if the game folder is currently modded (update.pak exists and contains game files)
        /// </summary>
        private static bool CheckIsGameModded()
        {
            string? gamePath = LocalStorage.GamePath;
            string updatePath = Path.Join(gamePath, "archives", "update.pak");

            if (gamePath == null || !File.Exists(updatePath))
            {
                return false;
            }

            IgArchive update = IgArchive.Open(updatePath);

            return update.GetFiles().Any(f =>
            {
                string name = f.GetName(false).ToLower();
                return name != "chunkinfos_pkg" && !name.EndsWith("_custom_zoneinfo");
            });
        }

        /// <summary>
        /// Apply selected mods
        /// </summary>
        private void OnClickApply()
        {
            // Retrieve files and solve conflicts
            Dictionary<string, IgArchiveFile> files = [];

            List<string> enabledMods = _modPaths.Where(path => _enabledMods.Contains(path)).Reverse().ToList();

            if (enabledMods.Count == 0) return;

            foreach (string path in enabledMods)
            {
                IgArchive archive = IgArchive.Open(path);

                foreach (IgArchiveFile file in archive.GetFiles())
                {
                    files[file.GetPath()] = file;
                }
            }

            if (LocalStorage.GamePath == null)
            {
                ModalRenderer.ShowMessageModal("Could not complete operation", "Game path is not set.");
                return;
            }

            // Create update.pak
            string updatePath = Path.Join(LocalStorage.GamePath, "archives", "update.pak");

            IgArchive update = new IgArchive(updatePath);

            foreach (IgArchiveFile file in files.Values)
            {
                update.AddFile(file);
            }

            update.Save();

            _isGameModded = true;
            ModalRenderer.ShowMessageModal("Information", $"{enabledMods.Count} mod{(enabledMods.Count > 1 ? "s were" : " was")} applied to the game!");
        }

        /// <summary>
        /// Revert the game to its original state
        /// </summary>
        private void OnClickUnmodGame()
        {
            if (LocalStorage.GamePath == null)
            {
                ModalRenderer.ShowMessageModal("Could not complete operation", "Game path is not set.");
                return;
            }

            string updatePath = Path.Join(LocalStorage.GamePath, "archives", "update.pak");
            
            if (File.Exists(updatePath))
            {
                File.Delete(updatePath);
            }

            _isGameModded = false;
            ModalRenderer.ShowMessageModal("Information", "The game has been reverted to its original state!");
        }
        
        /// <summary>
        /// Add a new mod to the list using the file explorer
        /// </summary>
        private void OnClickAddMod()
        {
            List<string> files = FileExplorer.OpenFiles("", FileExplorer.EXT_ARCHIVES, true);
            if (files.Count == 0) return;

            foreach (string file in files)
            {
                if (_modPaths.Contains(file)) continue;
                _modPaths.Add(file);
                _enabledMods.Add(file);
            }

            SaveToLocalStorage();
        }
        
        /// <summary>
        /// Remove a mod from the list
        /// </summary>
        /// <param name="path"></param>
        private void OnClickDeleteMod(string path)
        {
            _modPaths.Remove(path);
            _enabledMods.Remove(path);

            SaveToLocalStorage();
        }

        /// <summary>
        /// Open the file explorer to locate a missing mod
        /// </summary>
        private void OnClickLocateMod(string path)
        {
            List<string> files = FileExplorer.OpenFiles(Path.GetDirectoryName(path) ?? "", FileExplorer.EXT_ARCHIVES, false);
            if (files.Count != 1) return;

            string filePath = files[0];

            int index = _modPaths.IndexOf(path);
            if (index != -1)
            {
                _modPaths[index] = filePath;
                _enabledMods.Add(filePath);
                
                SaveToLocalStorage();
            }
        }
        
        /// <summary>
        /// Enable or disable a mod
        /// </summary>
        private void OnToggleModEnabled(string path, bool enabled)
        {
            if (enabled && !_enabledMods.Contains(path))
            {
                _enabledMods.Add(path);
            }
            else if (!enabled && _enabledMods.Contains(path))
            {
                _enabledMods.Remove(path);
            }

            SaveToLocalStorage();
        }

        /// <summary>
        /// Launch the game executable with the current selected level
        /// </summary>
        private void OnClickLaunchGame()
        {
            PlayButtonTimeout();

            if (_selectedLevel <= 0)
            {
                LaunchLevel();
                return;
            }

            string levelPath = _levels[_selectedLevel];
            levelPath += "/" + levelPath.Split('/').Last();
            LaunchLevel(levelPath);
        }

        public static void LaunchLevel(string? levelPath = null)
        {
            if (LocalStorage.GamePath == null)
            {
                ModalRenderer.ShowMessageModal("Could not complete operation", "Game path is not set.");
                return;
            }

            string exePath = Path.Join(LocalStorage.GamePath, "CrashBandicootNSaneTrilogy.exe");
            string args = levelPath == null ? "" : $"-om {levelPath}";

            Console.WriteLine($"{exePath} {args}");

            Process.Start(new ProcessStartInfo
            {
                FileName = $"{exePath}",
                Arguments = args,
                UseShellExecute = true
            });
        }

        /// <summary>
        /// Save the mod list to local storage
        /// </summary>
        private void SaveToLocalStorage()
        {
            LocalStorage.Set("mod_paths", _modPaths);
            LocalStorage.Set("enabled_mods", _enabledMods);
        }

        /// <summary>
        /// Render the mod manager
        /// </summary>
        public void Render()
        {
            ImGui.SeparatorText("Manage active mods    ");

            // Tooltip
            ImGui.SameLine();
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() - ImGui.CalcTextSize("    ").X);
            ImGui.TextDisabled("(?)");
            if (ImGui.BeginItemTooltip())
            {
                ImGui.PushTextWrapPos(ImGui.GetFontSize() * 35);
                ImGui.TextWrapped("Load, manage and apply mods to the game.\n\n- Add mod(s): Add one or more mods (.pak) to the list\n- Apply Mods: Apply all *enabled* mods to the game\n- Unmod Game: Remove all mods from the game\n\nYou can click & hold items in the list to reorder them.\n\nIf some files are conflicting between mods, the priority will be given to the mod that appears first in the list.");
                ImGui.PopTextWrapPos();
                ImGui.EndTooltip();
            }

            ImGui.Spacing();

            if (_modPaths.Count == 0)
            {
                ImGui.Text("No active mods");
            }
            else
            {
                // Mod list
                for (int i = 0; i < _modPaths.Count; i++)
                {
                    RenderMod(i);
                }
            }

            ImGuiUtils.VerticalSpacing(10);
            
            // Action buttons
            if (ImGui.Button("Add mod(s)..."))
            {
                OnClickAddMod();
            }

            if (_isGameModded || _modPaths.Count > 0)
            {
                ImGui.SameLine();
                
                if (_isGameModded)
                {
                    ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(1, .2f, 0, 0.5f));
                    if (ImGuiUtils.RightAlignedButton("Unmod game"))
                    {
                        OnClickUnmodGame();
                    }
                    ImGui.PopStyleColor();
                }
                if (_modPaths.Count > 0)
                {
                    ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0, 1, .2f, 0.5f));
                    if (ImGuiUtils.RightAlignedButton("Apply mods"))
                    {
                        OnClickApply();
                    }
                    ImGui.PopStyleColor();
                }
            }

            RenderLevelSelect();
        }

        /// <summary>
        /// Render the level select dropdown
        /// </summary>
        private void RenderLevelSelect()
        {
            float buttonPaddingX = ImGui.GetContentRegionAvail().X * 0.1f;
            float buttonWidth = ImGui.CalcTextSize("Launch game").X + buttonPaddingX * 2;

            ImGuiUtils.VerticalSpacing(20);
            ImGui.SetNextItemWidth(ImGui.GetContentRegionAvail().X - buttonWidth);

            if (ImGui.Combo("##SelectedLevel", ref _selectedLevel, _levels, _levels.Length))
            {
                LocalStorage.Set("selected_level", _selectedLevel);
            }
            ImGui.SameLine();

            bool isButtonActive = CanClickPlay;

            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(buttonPaddingX, ImGui.GetStyle().FramePadding.Y));
            if (!isButtonActive) ImGui.BeginDisabled();
            if (ImGui.Button("Launch game"))
            {
                OnClickLaunchGame();
            }
            if (!isButtonActive) ImGui.EndDisabled();
            ImGui.PopStyleVar();
        }

        /// <summary>
        /// Render a single mod
        /// </summary>
        private void RenderMod(int i)
        {
            string path = _modPaths[i];
            string name = Path.GetFileNameWithoutExtension(path);
            bool isModEnabled = _enabledMods.Contains(path);
            bool isModMissing = _missingMods.Contains(path);

            Vector4 textColor = isModEnabled ? new Vector4(1, 1, 1, 1) : new Vector4(0.5f, 0.5f, 0.5f, 1);
            if (isModMissing) textColor = new Vector4(.6f, 0, 0, 1);

            // Mod name and index
            ImGui.PushStyleColor(ImGuiCol.Text, textColor);
            ImGui.Text($"{i+1}.");
            ImGui.SameLine();
            ImGui.SetNextItemAllowOverlap();
            ImGui.Selectable(name + (isModMissing ? " (Missing)" : ""));
            ImGui.PopStyleColor();

            // Store state properties
            bool isHovered = ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenOverlapped);
            bool isHoveredDelay = ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenOverlapped | ImGuiHoveredFlags.DelayShort | ImGuiHoveredFlags.NoSharedDelay);
            bool isActive = ImGui.IsItemActive();

            // Store border properties
            const float thickness = 2.0f;
            var drawList = ImGui.GetWindowDrawList();
            Vector2 min = ImGui.GetItemRectMin();
            Vector2 max = ImGui.GetItemRectMax();
            uint color = ImGui.GetColorU32(new Vector4(1, 1, 0, 1));

            // Render action buttons
            {
                ImGui.SameLine();
                float buttonsWidth = ImGui.CalcTextSize("Remove X X").X + ImGui.GetStyle().FramePadding.X * 4;
                ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - buttonsWidth);
                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.2f, 0.2f, 0.2f, 1.0f));

                ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(0, 0));

                if (isModMissing)
                {
                    bool dummy = false;
                    ImGui.Checkbox("##Checkbox" + i, ref dummy);
                }
                else if (ImGui.Checkbox("##Checkbox" + i, ref isModEnabled))
                {
                    OnToggleModEnabled(path, isModEnabled);
                }
                if (ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenOverlapped))
                {
                    isHoveredDelay = false;
                    ImGui.SetTooltip(isModEnabled ? "Disable" : "Enable");
                }

                ImGui.PopStyleVar();

                ImGui.SameLine();
                if (ImGui.SmallButton("\u00d7##" + i))
                {
                    OnClickDeleteMod(path);
                }
                if (ImGui.IsItemHovered(ImGuiHoveredFlags.AllowWhenOverlapped))
                {
                    isHoveredDelay = false;
                    ImGui.SetTooltip("Remove");
                }

                ImGui.SameLine();
                if (isModMissing && ImGui.SmallButton("Find##" + i))
                {
                    OnClickLocateMod(path);
                }
                else if (!isModMissing && ImGui.SmallButton("Open##" + i))
                {
                    App.OpenArchive(path);
                }

                ImGui.PopStyleColor();
            }

            if (!isActive)
            {
                if (isHoveredDelay)
                {
                    ImGui.SetTooltip(path);
                }

                return;
            }

            if (isHovered)
            {
                // Add border on drag
                drawList.AddRect(min, max, color, 0.0f, ImDrawFlags.None, thickness);
            }
            else
            {
                int i_next = i + (ImGui.GetMouseDragDelta(0).Y < 0 ? -1 : 1);

                // Reordering
                if (i_next >= 0 && i_next < _modPaths.Count)
                {
                    _modPaths[i] = _modPaths[i_next];
                    _modPaths[i_next] = path;
                    ImGui.ResetMouseDragDelta();
                    SaveToLocalStorage();
                }
            }
        }
    }
}