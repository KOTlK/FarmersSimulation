using Game.Runtime.View.World.Smoke;
using UnityEditor;
using UnityEngine;

namespace Game.Editor.Smoke
{
    [CustomEditor(typeof(SmokeCloud))]
    public class SmokeEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            if (GUILayout.Button("Regenerate"))
            {
                ((SmokeCloud)serializedObject.targetObject).Regenerate();
            }
            
        }
    }
}