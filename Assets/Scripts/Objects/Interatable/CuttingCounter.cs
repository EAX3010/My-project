using Assets.Interface;
using Assets.Scripts.Interface;
using Assets.Scripts.Objects.Interatable;
using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    public EventHandler OnPlayerAltAction;

    public override void Interact(Player player)
    {
        Debug.Log("E - Interacting with a counter");
        bool PlayerHasObject = player.HasKitchenObject();
        bool CounterHasObject = HasKitchenObject();
        if (!PlayerHasObject && CounterHasObject)
        {
            this.GetKitchenObject().MoveTo(player);
        }
        else if (PlayerHasObject && !CounterHasObject)
        {
            player.GetKitchenObject().MoveTo(this);
        }
        else if (PlayerHasObject && CounterHasObject)
        {
            KitchenObject.Exchange(player, this, this.GetKitchenObject(), player.GetKitchenObject(), this);
        }
    }

    public override void AltInteract(Player player)
    {
        OnPlayerAltAction.Invoke(this, null);
    }
}
