using Assets.Interface;
using Assets.Scripts.Interface;
using Assets.Scripts.Objects.Interatable;
using System;
using UnityEngine;

public class TrashCounter : MonoBehaviour, IInteractableObject
{
    [SerializeField]
    private ClearCounterSelected isSelected;
    public  void Interact(Player player)
    {
        Debug.Log("E - Interacting with a Trash");
        bool PlayerHasObject = player.HasKitchenObject();
        if (PlayerHasObject)
        {
            player.GetKitchenObject().RemoveItem();
        }
    }
    
    public void HoverOn(Player player)
    {
        isSelected?.Enable();
    }
    public void HoverOff(Player player)
    {
        isSelected?.Disable();
    }
    public void AltInteract(Player player)
    {
       return;
    }
}
