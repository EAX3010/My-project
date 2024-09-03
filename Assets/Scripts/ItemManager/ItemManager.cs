using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    public Player player;
    [SerializeField]
    public List<KitchenScriptableObjects> items;
   
    private void OnGUI()
    {
        if (items == null || items.Count == 0)
        {
            GUILayout.Label("No items available.");
            return;
        }
        GUILayout.Label("Select an Item:", EditorStyles.boldLabel);

        foreach (var item in items)
        {
            if (GUILayout.Button(item.itemName))
            {
                player.itemSelected = item;    
                Debug.Log($"Selected item: {item.name}");
            }
        }
    }
}