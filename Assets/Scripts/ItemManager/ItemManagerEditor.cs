using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(ItemManager))]
public class ItemManagerEditor : Editor
{
    private SerializedProperty itemList;
    private SerializedProperty player;
    private void OnEnable()
    {
        itemList = serializedObject.FindProperty("items");
        player = serializedObject.FindProperty("player");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Player", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(player, true);

        EditorGUILayout.LabelField("Item List", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(itemList, true);

        serializedObject.ApplyModifiedProperties();
    }
}
