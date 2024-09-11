using Assets.Scripts.Interface;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    public KitchenScriptableObjects itemInfo;
    private IKitchenObjectParent parentObject;

    public float lurpSpeed = 100.0f; // Speed of interpolation

    public void MoveTo(IKitchenObjectParent parentObject, bool smothMove = true)
    {
        //Clear the current parent object
        if (this.parentObject != null)
            this.parentObject.SetKitchenObject(null);

        //Set the new parent object
        this.parentObject = parentObject;
        this.parentObject.SetKitchenObject(this);
        if (smothMove)
        {
           StartCoroutine(SmoothMove(parentObject.GetSpawnPoint()));
        }
        else
        {
            this.transform.parent = parentObject.GetSpawnPoint();
            this.transform.localPosition = Vector3.zero;
        }
        this.transform.FaceObjectToCamera();
    }

    private IEnumerator SmoothMove(Transform newParent)
    {
        Vector3 startPosition = this.transform.position;
        Quaternion startRotation = this.transform.rotation;
        Vector3 targetPosition = newParent.position;
        float progress = 0;
        while (progress < 1)
        {
            progress += lurpSpeed * Time.deltaTime;
            //Debug.Log("Progress: " + progress);
            this.transform.position = Vector3.Slerp(startPosition, targetPosition, progress);
            yield return null;
        }
      
        this.transform.position = targetPosition;
        this.transform.parent = newParent;
        this.transform.localPosition = Vector3.zero;

    }

    public static void Exchange(IKitchenObjectParent parentObject1, IKitchenObjectParent parentObject2, KitchenObject kitchenObject1, KitchenObject kitchenObject2, MonoBehaviour instance)
    {
        kitchenObject1.parentObject = parentObject1;
        kitchenObject1.parentObject.SetKitchenObject(kitchenObject1);
        instance.StartCoroutine(kitchenObject1.SmoothMove(parentObject1.GetSpawnPoint()));
        kitchenObject1.transform.FaceObjectToCamera();


        kitchenObject2.parentObject = parentObject2;
        kitchenObject2.parentObject.SetKitchenObject(kitchenObject2);
        instance.StartCoroutine(kitchenObject2.SmoothMove(parentObject2.GetSpawnPoint()));
        kitchenObject2.transform.FaceObjectToCamera();
    }

    public void RemoveItem()
    {
        Destroy(this.gameObject);
    }

    public IKitchenObjectParent Holder()
    {
        return parentObject;
    }
}
