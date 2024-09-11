using Assets.Interface;
using Assets.Scripts.Interface;
using Assets.Scripts.Objects.Interatable;
using System;
using UnityEngine;

public class FoodCounter : BaseCounter
{
    [SerializeField]
    private KitchenScriptableObjects spawnType;
    public event EventHandler OnPlayerGrabbingObject;
    private KitchenObject kitchenObject;

    private void Awake()
    {
        this.GetComponentInChildren<SpriteRenderer>().sprite = spawnType.sprite;
    }
    public override void Interact(Player player)
    {
        Debug.Log("E - Interacting with a food counter");
        bool PlayerHasObject = player.HasKitchenObject();
        if (!PlayerHasObject)
        {
            var item = Instantiate(spawnType.prefab);
            item.GetComponent<KitchenObject>().MoveTo(this, false);//for smooth move
            item.GetComponent<KitchenObject>().MoveTo(player, true);
            OnPlayerGrabbingObject.Invoke(this, EventArgs.Empty);
        }
    }
   
}
