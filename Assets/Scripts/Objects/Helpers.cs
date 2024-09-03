using System;
using UnityEngine;
using System.Linq;
public static partial class Helpers 
{
    public static void FaceObjectToCamera(this Transform objectTransform)
    {
        Vector3 directionToCamera = Camera.main.transform.position - objectTransform.position;
        directionToCamera.y = 0;
        objectTransform.rotation = Quaternion.LookRotation(directionToCamera);
    }
    
}