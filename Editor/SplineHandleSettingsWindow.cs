using UnityEngine;
using UnityEngine.UIElements;

namespace SplinesExtensions.Editor
{
    /// <summary>
    /// Popup window for quick toggles: Flow Direction, All Tangents, Knot Indices, Show Mesh.
    /// Uses UnityEditor.Splines.SplineHandleSettings from the Splines package.
    /// </summary>
    sealed class SplineHandleSettingsWindow : UnityEditor.EditorWindow
    {
        const float k_BorderWidth = 1;

        Toggle m_FlowDirection;
        Toggle m_AllTangents;
        Toggle m_KnotIndices;
        Toggle m_SplineMesh;

        public static void Show(Rect buttonRect)
        {
            var window = CreateInstance<SplineHandleSettingsWindow>();
            window.hideFlags = HideFlags.DontSave;

#if UNITY_2022_1_OR_NEWER
            var popupWidth = 150;
#else
            var popupWidth = 180;
#endif
            window.ShowAsDropDown(GUIUtility.GUIToScreenRect(buttonRect), new Vector2(popupWidth, 80));
        }

        void OnEnable()
        {
            Color borderColor = UnityEditor.EditorGUIUtility.isProSkin
                ? new Color(0.44f, 0.44f, 0.44f, 1f)
                : new Color(0.51f, 0.51f, 0.51f, 1f);

            rootVisualElement.style.borderLeftWidth = k_BorderWidth;
            rootVisualElement.style.borderTopWidth = k_BorderWidth;
            rootVisualElement.style.borderRightWidth = k_BorderWidth;
            rootVisualElement.style.borderBottomWidth = k_BorderWidth;
            rootVisualElement.style.borderLeftColor = borderColor;
            rootVisualElement.style.borderTopColor = borderColor;
            rootVisualElement.style.borderRightColor = borderColor;
            rootVisualElement.style.borderBottomColor = borderColor;

            rootVisualElement.Add(m_FlowDirection = new Toggle(UnityEditor.L10n.Tr("Flow Direction")) { style = { flexDirection = FlexDirection.RowReverse } });
            rootVisualElement.Add(m_AllTangents = new Toggle(UnityEditor.L10n.Tr("All Tangents")) { style = { flexDirection = FlexDirection.RowReverse } });
            rootVisualElement.Add(m_KnotIndices = new Toggle(UnityEditor.L10n.Tr("Knot Indices")) { style = { flexDirection = FlexDirection.RowReverse } });
            rootVisualElement.Add(m_SplineMesh = new Toggle(UnityEditor.L10n.Tr("Show Mesh")) { style = { flexDirection = FlexDirection.RowReverse } });

            m_FlowDirection.RegisterValueChangedCallback(evt => { UnityEditor.Splines.SplineHandleSettings.FlowDirectionEnabled = evt.newValue; UnityEditor.SceneView.RepaintAll(); });
            m_AllTangents.RegisterValueChangedCallback(evt => { UnityEditor.Splines.SplineHandleSettings.ShowAllTangents = evt.newValue; UnityEditor.SceneView.RepaintAll(); });
            m_KnotIndices.RegisterValueChangedCallback(evt => { UnityEditor.Splines.SplineHandleSettings.ShowKnotIndices = evt.newValue; UnityEditor.SceneView.RepaintAll(); });
            m_SplineMesh.RegisterValueChangedCallback(evt => { UnityEditor.Splines.SplineHandleSettings.ShowMesh = evt.newValue; UnityEditor.SceneView.RepaintAll(); });

            UpdateValues();
        }

        void UpdateValues()
        {
            m_FlowDirection.SetValueWithoutNotify(UnityEditor.Splines.SplineHandleSettings.FlowDirectionEnabled);
            m_AllTangents.SetValueWithoutNotify(UnityEditor.Splines.SplineHandleSettings.ShowAllTangents);
            m_KnotIndices.SetValueWithoutNotify(UnityEditor.Splines.SplineHandleSettings.ShowKnotIndices);
            m_SplineMesh.SetValueWithoutNotify(UnityEditor.Splines.SplineHandleSettings.ShowMesh);
            UnityEditor.SceneView.RepaintAll();
        }
    }
}
