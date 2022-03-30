using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CreatureSpawner))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CreatureSpawner spawner = (CreatureSpawner)target;
        if (GUILayout.Button("Refresh Dinosaurs"))
        {
            spawner.RefreshDinos();
        }
    }
}
