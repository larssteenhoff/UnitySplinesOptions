# Splines Project Settings

This add-on adds a **Project Settings** page for Unity Splines.

## Accessing

**Edit > Project Settings > Splines**

## Handle size settings

- **Global Handle Size** (1.0–4.0) – Multiplier for all handle sizes.
- **Knot Handle Size** (0.3–4.0) – Multiplier for knot handles (used only if the Splines package is patched to read it).
- **Tangent Handle Size** (0.3–4.0) – Multiplier for tangent handles.

## Colors

- **Spline Color** – Line in front of geometry.
- **Spline Line Behind Color** – Line behind geometry.
- **Knot Color** – Knot handle color.
- **Tangent Color** – Tangent handle color.

## Note

Values are stored in EditorPrefs. The **official** com.unity.splines package does not read these keys for drawing; only the add-on’s UI uses them. To have sizes and colors affect the Scene view, you need to patch your local copy of the Splines package (see the repository’s `patches/` instructions).

## Visuals dropdown

When using the Spline tools, the **Visuals** dropdown in the toolbar gives quick toggles for:

- Flow Direction  
- All Tangents  
- Knot Indices  
- Show Mesh  

These use the Splines package’s existing preferences.
