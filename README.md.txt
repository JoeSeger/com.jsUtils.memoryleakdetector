# Unity Memory Leak Detector Toggle

This package adds a menu item in the "Tools" menu to toggle memory leak diagnostics in Unity, using the command line argument `-diag-job-temp-memory-leak-validation`.

## Installation

To install this package, you can use the Unity Package Manager. Follow these steps:

1. Open your Unity project.
2. Open the Package Manager window by selecting `Window > Package Manager` from the menu.
3. Click the `+` button at the top of the Package Manager window and select `Add package from git URL`.
4. In the text box, enter the following URL: `https://github.com/JoeSeger/jsUtils.memoryLeakDetector`.
5. Click the `Add` button to install the package.

## Usage

To use the Memory Leak Detector Toggle, follow these steps:

1. Open your Unity project.
2. Select `Tools > Enable Leak Diagnostics` from the menu.
3. Unity will refresh and the Memory Leak Detector Toggle will be enabled.

To disable the Memory Leak Detector Toggle, simply select `Tools > Enable Leak Diagnostics` from the menu again.

## Code

Here is an example of how to use the Memory Leak Detector Toggle in your own code:

```csharp
using UnityEditor;
using UnityEditor.Build;

namespace memoryLeakDetector.Editor
{
    // Adds a menu item in the "Tools" menu to toggle memory leak diagnostics
    public static class MemoryLeakDetectorToggle
    {
        // ...
        // Your code here
        // ...
    }
}
