using UnityEngine;
using UnityEditor;

namespace SplinesExtensions.Samples
{
    /// <summary>
    /// Example: read Project Settings (EditorPrefs) and SplineHandleSettings from the Splines package.
    /// Add to a GameObject and enter Play mode to see the display.
    /// </summary>
    public class SplineSettingsTest : MonoBehaviour
    {
        [Header("Handle sizes (from Project Settings / EditorPrefs)")]
        [SerializeField] float globalHandleSize;
        [SerializeField] float knotHandleSize;
        [SerializeField] float tangentHandleSize;

        [Header("Colors (from Project Settings / EditorPrefs)")]
        [SerializeField] Color splineColor;
        [SerializeField] Color splineLineBehindColor;
        [SerializeField] Color knotColor;
        [SerializeField] Color tangentColor;

        [Header("Display options (from Splines package preferences)")]
        [SerializeField] bool flowDirection;
        [SerializeField] bool showAllTangents;
        [SerializeField] bool showKnotIndices;
        [SerializeField] bool showMesh;

        void OnValidate() => Refresh();

        void Refresh()
        {
            globalHandleSize = EditorPrefs.GetFloat("Splines.GlobalHandleSize", 1.0f);
            knotHandleSize = EditorPrefs.GetFloat("Splines.KnotHandleSize", 1.0f);
            tangentHandleSize = EditorPrefs.GetFloat("Splines.TangentHandleSize", 1.0f);

            splineColor = GetColor("Splines.SplineColor", Color.cyan);
            splineLineBehindColor = GetColor("Splines.SplineLineBehindColor", new Color(0f, 0f, 0f, 0.4f));
            knotColor = GetColor("Splines.KnotColor", Color.yellow);
            tangentColor = GetColor("Splines.TangentColor", Color.black);

            flowDirection = UnityEditor.Splines.SplineHandleSettings.FlowDirectionEnabled;
            showAllTangents = UnityEditor.Splines.SplineHandleSettings.ShowAllTangents;
            showKnotIndices = UnityEditor.Splines.SplineHandleSettings.ShowKnotIndices;
            showMesh = UnityEditor.Splines.SplineHandleSettings.ShowMesh;
        }

        static Color GetColor(string key, Color defaultColor)
        {
            string html = EditorPrefs.GetString(key, ColorUtility.ToHtmlStringRGBA(defaultColor));
            return ColorUtility.TryParseHtmlString("#" + html, out Color c) ? c : defaultColor;
        }

        void OnGUI()
        {
            if (!Application.isPlaying) return;

            GUILayout.BeginArea(new Rect(10, 10, 320, 420));
            GUILayout.Label("Splines Extensions – Settings", EditorStyles.boldLabel);
            GUILayout.Space(8);

            GUILayout.Label("Handle sizes (Project Settings)", EditorStyles.boldLabel);
            GUILayout.Label($"Global: {globalHandleSize:F2}x  Knot: {knotHandleSize:F2}x  Tangent: {tangentHandleSize:F2}x");
            GUILayout.Space(6);

            GUILayout.Label("Colors (Project Settings)", EditorStyles.boldLabel);
            GUILayout.Label($"Spline: {splineColor}  Knot: {knotColor}  Tangent: {tangentColor}");
            GUILayout.Space(6);

            GUILayout.Label("Display (Splines preferences)", EditorStyles.boldLabel);
            GUILayout.Label($"Flow: {flowDirection}  All tangents: {showAllTangents}  Indices: {showKnotIndices}  Mesh: {showMesh}");
            GUILayout.Space(10);

            if (GUILayout.Button("Refresh"))
                Refresh();

            GUILayout.Space(6);
            GUILayout.Label("Edit > Project Settings > Splines to change values.", EditorStyles.helpBox);
            GUILayout.EndArea();
        }
    }
}
