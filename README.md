# Unity Splines Options

Editor extensions and settings UI for **Unity Splines** (com.unity.splines). This repository contains **only original additions**—no Unity source code is distributed.

## License compliance

- **Unity Splines** is © Unity Technologies ApS and licensed under the [Unity Companion License](https://unity.com/legal/licenses/unity-companion-license). You must use it under a valid Unity engine license.
- **This repository** does not include or redistribute any code from Unity’s Splines package. Only the following are provided:
  - New editor scripts (Project Settings provider, Visuals dropdown, sample).
  - Documentation and optional **patch instructions** so you can apply the same behavior to your **local copy** of the package.
- Code in this repo that is original work is licensed under the **MIT License** (see [LICENSE](LICENSE)).

## What this adds

- **Project Settings** (`Edit > Project Settings > Splines`): Handle sizes (global, knot, tangent) and colors (spline, knot, tangent, line-behind).
- **Visuals dropdown** in the Spline tool toolbar: Quick toggles for Flow Direction, All Tangents, Knot Indices, Show Mesh.
- **Sample**: `SplineSettingsTest` shows how to read these settings (when used with the extended package or add-on).

Full behavior (handle size and colors actually affecting Scene view handles) requires that the Splines package **read** these settings. The official package does not do that out of the box. You have two options:

1. **Add-on only**  
   Install the add-on package below. You get the Project Settings UI and the Visuals dropdown. Handle/color changes in the Scene view will only take effect if your Splines package has been patched (see [Patches](#3-optional-patches-for-full-behavior)).

2. **Add-on + patches**  
   Apply the optional patches to your **local** copy of com.unity.splines (obtained from Unity). Then the same settings control handle sizes and colors in the Scene view. Patches are applied by you to your copy; this repo does not ship Unity code.

## Installation

### 1. Add the official Splines package

In Unity: **Window > Package Manager**, add **Splines** (com.unity.splines) from Unity’s registry if you don’t have it already.

### 2. Add this add-on (your code only)

- **Git URL (recommended)**  
  In Unity: **Window > Package Manager > + > Add package from git URL**, then paste:
  ```
  https://github.com/YOUR_USERNAME/UnitySplinesOptions.git
  ```
  Replace `YOUR_USERNAME` with your GitHub username or org (e.g. `Lars`).

- **Local path**  
  Clone this repo, then in your project’s `Packages/manifest.json` add:
  ```json
  "com.lars.unity-splines-options": "file:/path/to/UnitySplinesOptions"
  ```
  Example if the repo is next to your project:  
  `"com.lars.unity-splines-options": "file:../UnitySplinesOptions"`

After adding the package you will have:
- **Edit > Project Settings > Splines** for handle size and color settings.
- The **Visuals** dropdown in the Spline tool toolbar (Flow Direction, All Tangents, Knot Indices, Show Mesh).

### 3. (Optional) Patches for full behavior

To have handle sizes and colors from Project Settings/Preferences actually affect the Scene view, the Splines package must be modified. We do **not** redistribute Unity’s code. You can:

- Apply the changes yourself to your local copy of the package (e.g. from Package Manager, copy the package to `Packages/com.unity.splines` and edit), or  
- Use the instructions and file list in [patches/README.md](patches/README.md) to generate and apply patches from your own extended package.

See [patches/README.md](patches/README.md) for which files are modified and how to generate/apply patches.

## Requirements

- Unity 2022.3+ (or the version required by com.unity.splines).
- **Splines** package (com.unity.splines) from Unity.

## Repository layout

- Package at repo root: `package.json`, `Editor/`, `Documentation~/`, `Samples~/` (install via Git URL).
- `patches/` – Instructions and list of modified files; no Unity source, only how to patch your copy.

## Trademarks

Unity and related marks are trademarks of Unity Technologies. This project is not affiliated with Unity Technologies.
