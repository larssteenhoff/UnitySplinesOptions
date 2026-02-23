using UnityEditor.EditorTools;
using UnityEditor.Toolbars;
using UnityEngine;
using UnityEngine.UIElements;

namespace SplinesExtensions.Editor
{
    /// <summary>
    /// Toolbar dropdown that opens the Visuals popup (Flow Direction, All Tangents, Knot Indices, Show Mesh).
    /// </summary>
    [EditorToolbarElement("Spline Tool Settings/Handle Visuals")]
    sealed class SplineHandleSettingsDropdown : EditorToolbarDropdown
    {
        public SplineHandleSettingsDropdown()
        {
            var content = EditorGUIUtility.TrTextContent("Visuals", "Visual settings for handles");
            text = content.text;
            tooltip = content.tooltip;
            icon = (Texture2D)content.image;
            clicked += OnClick;
            RegisterCallback<AttachToPanelEvent>(AttachToPanel);
        }

        void OnClick()
        {
            SplineHandleSettingsWindow.Show(worldBound);
        }

        void AttachToPanel(AttachToPanelEvent evt)
        {
            var toolType = ToolManager.activeToolType;
            var knotPlacementType = System.Type.GetType("UnityEditor.Splines.KnotPlacementTool, Unity.Splines.Editor");
            SetEnabled(knotPlacementType == null || toolType != knotPlacementType);
        }
    }
}
