using UnityEditor;
using UnityEditor.Build;

namespace jsUtils.memoryLeakDetector
{
    /// <summary>
    /// Adds a menu item in the "Tools" menu to toggle memory leak diagnostics
    /// using the command line argument "-diag-job-temp-memory-leak-validation".
    /// </summary>
    public static class MemoryLeakDetectorToggle
    {
        private const string CommandLineArgs = "-diag-job-temp-memory-leak-validation";
        private const string MenuPath = "Tools/Enable Leak Diagnostics";
        private const string RefreshingUnityEditor = "Refreshing Unity Editor";
        private const string PleaseWaitWhileTheUnityEditorRefreshes = "Please wait while the Unity editor refreshes...";
        private const float Progress = 0.5f;
        
        /// <summary>
        /// Toggles memory leak diagnostics for the active build target and refreshes the Unity editor with a progress bar.
        /// </summary>
        [MenuItem(MenuPath)]
        private static void ToggleLeakDiagnostics()
        {
            // Get the current build target and its corresponding NamedBuildTarget
            var currentBuildTarget = EditorUserBuildSettings.activeBuildTarget;
            var currentBuildTargetGroup = BuildPipeline.GetBuildTargetGroup(currentBuildTarget);
            var namedBuildTarget = NamedBuildTarget.FromBuildTargetGroup(currentBuildTargetGroup);

            // Check if memory leak diagnostics are enabled
            var currentArgs = PlayerSettings.GetScriptingDefineSymbols(namedBuildTarget);
            var isEnabled = currentArgs.Contains(CommandLineArgs);

            // Toggle memory leak diagnostics and update the scripting define symbols
            var newArgs = isEnabled ? currentArgs.Replace(CommandLineArgs, "").Replace(";;", ";") : $"{currentArgs};{CommandLineArgs}";
            PlayerSettings.SetScriptingDefineSymbols(namedBuildTarget, newArgs);
            Menu.SetChecked(MenuPath, !isEnabled);

            // Display a progress bar during the Unity editor refresh
            EditorUtility.DisplayProgressBar(RefreshingUnityEditor, PleaseWaitWhileTheUnityEditorRefreshes, Progress);

            // Refresh the Unity editor
            AssetDatabase.Refresh();

            // Clear the progress bar
            EditorUtility.ClearProgressBar();
        }

        /// <summary>
        /// Validates the memory leak diagnostics toggle and updates its checked state.
        /// </summary>
        [MenuItem(MenuPath, true)]
        private static bool ValidateToggleLeakDiagnostics()
        {
            // Get the current build target and its corresponding NamedBuildTarget
            var currentBuildTarget = EditorUserBuildSettings.activeBuildTarget;
            var currentBuildTargetGroup = BuildPipeline.GetBuildTargetGroup(currentBuildTarget);
            var namedBuildTarget = NamedBuildTarget.FromBuildTargetGroup(currentBuildTargetGroup);

            // Check if memory leak diagnostics are enabled
            var currentArgs = PlayerSettings.GetScriptingDefineSymbols(namedBuildTarget);
            var isEnabled = currentArgs.Contains(CommandLineArgs);

            // Update the checked state of the menu item based on the diagnostics status
            Menu.SetChecked(MenuPath, isEnabled);
            return true;
        }
    }
}
