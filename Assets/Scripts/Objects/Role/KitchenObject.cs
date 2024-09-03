using Assets.Scripts.Interface;
using Unity.VisualScripting;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    public KitchenScriptableObjects itemInfo;
    private IKitchenObjectParent parentObject;

    public void SetClearCounter(IKitchenObjectParent parentObject, KitchenScriptableObjects kitchenItem)
    {
        if (this.parentObject != null)
            this.parentObject.SetKitchenObject(null);


        this.parentObject = parentObject;
        this.parentObject.SetKitchenObject(this);
        this.transform.parent = parentObject.GetSpawnPoint();
        this.transform.localPosition = Vector3.zero;
        this.transform.FaceObjectToCamera();
        SetItem(kitchenItem);
    }
    public void RemoveItem()
    {
        this.gameObject.SetActive(false);
    }
    public IKitchenObjectParent GetClearCounter()
    {
        return parentObject;
    }
    public void SetItem(KitchenScriptableObjects itemInfo)
    {
        this.itemInfo = itemInfo;
    }

}