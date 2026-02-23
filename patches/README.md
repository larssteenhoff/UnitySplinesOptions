# Optional patches (for full handle size and color behavior)

The add-on in this repo provides the **UI** (Project Settings and Visuals dropdown). The **official** Unity Splines package does not read those settings when drawing handles in the Scene view.

To have **handle sizes** and **colors** from Project Settings actually affect the Scene view, you must modify your **local copy** of the com.unity.splines package. This repo does **not** include or redistribute any of Unity’s code.

## Legal note

Any changes you make to Unity’s Splines package create a **derivative work** of the Work under the [Unity Companion License](https://unity.com/legal/licenses/unity-companion-license). That derivative work is owned by Unity (see section 3.2 of the license). You may use it for authoring/distribution in line with your Unity engine license. We do not distribute Unity code or derivative works—only instructions and, if you generate them, your own patch files.

## Files that were modified (in the extended package)

These paths are relative to the root of the **com.unity.splines** package (e.g. `Packages/com.unity.splines/`):

| Path | What changed |
|------|----------------|
| `Editor/Core/SplineProjectSettingsProvider.cs` | **Replaced** by the add-on; not needed if you use the add-on package. |
| `Editor/Controls/SplineHandleSettings.cs` | **Extended**: added settings for Knot Handle Size, Tangent Handle Size, Spline/Knot/Tangent colors, and Spline Mesh (Show Mesh, Mesh Color, Size, Resolution). |
| `Editor/Controls/SplineHandleSettingsWindow.cs` | **Replaced** by the add-on; optional if you use the add-on. |
| `Editor/GUI/ToolbarsOverlays/SplineHandleSettingsDropdown.cs` | **Replaced** by the add-on; optional if you use the add-on. |
| `Editor/Utilities/SplineHandleUtility.cs` | **Modified**: reads colors and handle size multipliers from EditorPrefs (e.g. `Splines.KnotColor`, `Splines.KnotHandleSize`, `Splines.GlobalHandleSize`, `Splines.TangentHandleSize`) and uses `KnotHandleSizeMultiplier` / `TangentHandleSizeMultiplier` for scaled knot and tangent disc radius. |
| `Editor/Utilities/SplineGizmoUtility.cs` | **Modified**: reads spline line color from EditorPrefs (`Splines.SplineColor`) instead of a hardcoded value. |

If you use the **add-on package**, you do **not** need to add or replace the Project Settings provider or the Visuals window/dropdown in the Splines package. You only need to patch the **behavior** (reading settings) in:

- `Editor/Controls/SplineHandleSettings.cs`
- `Editor/Utilities/SplineHandleUtility.cs`
- `Editor/Utilities/SplineGizmoUtility.cs`

## How to generate patches (from your extended package)

1. Install the **official** com.unity.splines package (e.g. via Package Manager).
2. Copy the official package to a temporary folder so you have “vanilla” source.
3. Copy your **modified** package files (the three above, or all listed) to another folder.
4. Use `diff` or `git diff` to generate patch files, for example:
   ```bash
   diff -u Packages/com.unity.splines/Editor/Utilities/SplineHandleUtility.cs \
          your-modified/Editor/Utilities/SplineHandleUtility.cs \
          > patches/SplineHandleUtility.patch
   ```
5. Store only the **patch files** in your repo or keep them locally. Do **not** commit Unity’s full source or full modified files.

## How to apply patches (to your local copy only)

1. Get the official Splines package (e.g. add via Package Manager, then copy it to `Packages/com.unity.splines` so it’s editable, or clone from Unity’s repository if you have access and the license allows).
2. From the repo root (or the folder that contains the package path):
   ```bash
   git apply patches/SplineHandleUtility.patch
   git apply patches/SplineHandleSettings.patch
   git apply patches/SplineGizmoUtility.patch
   ```
   Or use `patch -p1 < patches/SplineHandleUtility.patch` etc. Adjust paths in the patch or `-p` so they match your package layout.
3. Do **not** redistribute the patched package; use it only for your own projects under your Unity license.

## Summary

- **Add-on only**: You get Project Settings UI and the Visuals dropdown; handle/color values are stored but the stock package won’t use them for drawing.
- **Add-on + patches**: Apply the above patches to your **local** copy of the package so the same settings control handle sizes and colors in the Scene view. No Unity code is distributed from this repo.
