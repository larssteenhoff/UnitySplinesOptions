# Unity Splines Options

Editor extensions and settings UI for **Unity Splines** (com.unity.splines). Adds a Project Settings page and a Visuals dropdown in the Spline tool toolbar. This package contains only original code; no Unity Splines source is distributed.

### Preview

**[Watch preview video](https://github.com/larssteenhoff/UnitySplinesOptions/raw/main/SplinesOptions.mp4)**

---

## Features

- **Project Settings** (`Edit > Project Settings > Splines`) — Handle sizes (global, knot, tangent) and colors (spline line, knot, tangent, line-behind).
- **Visuals dropdown** — In the Spline tool toolbar: toggles for Flow Direction, All Tangents, Knot Indices, Show Mesh.
- **Sample** — `SplineSettingsTest` demonstrates reading the settings at runtime.

Handle and color values are stored in EditorPrefs. The official Splines package does not read these keys for drawing. For settings to affect Scene view handles, the Splines package must be patched locally (see [Patches](#optional-patches)).

---

## Installation

### 1. Splines package

Install **Splines** (com.unity.splines) from the Unity Package Manager if not already present.

### 2. This package

**From Git URL**

1. **Window > Package Manager > + > Add package from git URL**
2. Enter:
   ```
   https://github.com/larssteenhoff/UnitySplinesOptions.git
   ```

**From disk**

Add to `Packages/manifest.json`:

```json
"com.lars.unity-splines-options": "file:/path/to/UnitySplinesOptions"
```

Example (repo next to project):

```json
"com.lars.unity-splines-options": "file:../UnitySplinesOptions"
```

After installation:

- **Edit > Project Settings > Splines** — Handle size and color settings.
- **Visuals** dropdown in the Spline tool toolbar — Flow Direction, All Tangents, Knot Indices, Show Mesh.

### Optional patches

For handle sizes and colors to affect Scene view drawing, the Splines package must be modified. This repository does not redistribute Unity code. [patches/README.md](patches/README.md) describes which files are changed and how to generate or apply patches to a local copy of com.unity.splines.

---

## Requirements

- Unity 2022.3 or newer (or the version required by com.unity.splines)
- **Splines** (com.unity.splines) from Unity

---

## License

This package is licensed under the **MIT License** (see [LICENSE](LICENSE)).

Unity Splines is © Unity Technologies ApS and licensed under the [Unity Companion License](https://unity.com/legal/licenses/unity-companion-license). Use of Unity Splines is subject to a valid Unity engine license.

Unity and related marks are trademarks of Unity Technologies. This project is not affiliated with Unity Technologies.
