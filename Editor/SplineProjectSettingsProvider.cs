using UnityEditor;
using UnityEngine;

namespace SplinesExtensions.Editor
{
    /// <summary>
    /// Adds Project Settings UI for Splines (handle sizes and colors).
    /// Values are stored in EditorPrefs. To have them affect Scene view handles,
    /// the com.unity.splines package must be patched to read these keys.
    /// </summary>
    static class SplineProjectSettingsProvider
    {
        private const string k_GlobalHandleSizeKey = "Splines.GlobalHandleSize";
        private const string k_KnotHandleSizeKey = "Splines.KnotHandleSize";
        private const string k_TangentHandleSizeKey = "Splines.TangentHandleSize";
        private const string k_SplineColorKey = "Splines.SplineColor";
        private const string k_SplineLineBehindColorKey = "Splines.SplineLineBehindColor";
        private const string k_KnotColorKey = "Splines.KnotColor";
        private const string k_TangentColorKey = "Splines.TangentColor";

        [SettingsProvider]
        public static SettingsProvider CreateProvider()
        {
            var provider = new SettingsProvider("Project/Splines", SettingsScope.Project)
            {
                label = "Splines",
                guiHandler = (searchContext) =>
                {
                    EditorGUI.BeginChangeCheck();

                    DrawHandleSizeSettings();

                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("Colors", EditorStyles.boldLabel);

                    Color splineColor = GetColor(k_SplineColorKey, Color.cyan);
                    splineColor = EditorGUILayout.ColorField("Spline Color", splineColor);
                    SetColor(k_SplineColorKey, splineColor);

                    Color splineLineBehindColor = GetColor(k_SplineLineBehindColorKey, new Color(0f, 0f, 0f, 0.4f));
                    splineLineBehindColor = EditorGUILayout.ColorField("Spline Line Behind Color", splineLineBehindColor);
                    SetColor(k_SplineLineBehindColorKey, splineLineBehindColor);

                    Color knotColor = GetColor(k_KnotColorKey, Color.yellow);
                    knotColor = EditorGUILayout.ColorField("Knot Color", knotColor);
                    SetColor(k_KnotColorKey, knotColor);

                    Color tangentColor = GetColor(k_TangentColorKey, Color.black);
                    tangentColor = EditorGUILayout.ColorField("Tangent Color", tangentColor);
                    SetColor(k_TangentColorKey, tangentColor);

                    if (EditorGUI.EndChangeCheck())
                        SceneView.RepaintAll();
                }
            };
            return provider;
        }

        private static void DrawHandleSizeSettings()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Handle Size Settings", EditorStyles.boldLabel);

            float globalHandleSize = EditorPrefs.GetFloat(k_GlobalHandleSizeKey, 1.0f);
            globalHandleSize = EditorGUILayout.Slider("Global Handle Size", globalHandleSize, 1.0f, 4.0f);
            EditorPrefs.SetFloat(k_GlobalHandleSizeKey, globalHandleSize);

            float knotHandleSize = EditorPrefs.GetFloat(k_KnotHandleSizeKey, 1.0f);
            knotHandleSize = EditorGUILayout.Slider("Knot Handle Size", knotHandleSize, 0.3f, 4.0f);
            EditorPrefs.SetFloat(k_KnotHandleSizeKey, knotHandleSize);

            float tangentHandleSize = EditorPrefs.GetFloat(k_TangentHandleSizeKey, 1.0f);
            tangentHandleSize = EditorGUILayout.Slider("Tangent Handle Size", tangentHandleSize, 0.3f, 4.0f);
            EditorPrefs.SetFloat(k_TangentHandleSizeKey, tangentHandleSize);

            if (GUI.changed)
                SceneView.RepaintAll();
        }

        private static void SetColor(string key, Color color)
        {
            EditorPrefs.SetString(key, ColorUtility.ToHtmlStringRGBA(color));
        }

        private static Color GetColor(string key, Color defaultColor)
        {
            string html = EditorPrefs.GetString(key, ColorUtility.ToHtmlStringRGBA(defaultColor));
            return ColorUtility.TryParseHtmlString("#" + html, out Color color) ? color : defaultColor;
        }
    }
}
