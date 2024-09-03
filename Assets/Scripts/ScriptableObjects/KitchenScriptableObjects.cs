using UnityEngine;

[CreateAssetMenu(fileName = "KitchenScriptableObjects", menuName = "Scriptable Objects/KitchenScriptableObjects")]
public class KitchenScriptableObjects : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public string itemName;
}
