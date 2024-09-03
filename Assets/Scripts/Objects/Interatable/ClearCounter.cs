using Assets.Interface;
using Assets.Scripts.Interface;
using NUnit.Framework;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.Progress;

public class ClearCounter : MonoBehaviour, IInteractableObject, IKitchenObjectParent
{
    [SerializeField]
    private ClearCounter NextCounter;
    [SerializeField]
    private SelectedCounter isSelected;
    [SerializeField]
    private Transform spawnPoint;
    private KitchenObject kitchenObject;
    private Sprite defaultSprite;
    private SpriteRenderer counterIcon;

    private void Awake()
    {
        counterIcon = GetComponentInChildren<SpriteRenderer>();
        defaultSprite = counterIcon.sprite;
    }

    public void Interact(Player player)
    {
        Debug.Log("E - Interacting with counter");
        if (GetKitchenObject() == null && player.GetKitchenObject() == null)
        {
            var item = Instantiate(player.itemSelected.prefab);
            item.GetComponent<KitchenObject>().SetClearCounter(this, player.itemSelected);
        }
        else if (player.GetKitchenObject() == null)
        {
            kitchenObject.SetClearCounter(player, kitchenObject.itemInfo);
        }
        else if (GetKitchenObject() == null && player.GetKitchenObject() != null)
        {
            player.GetKitchenObject().SetClearCounter(this, player.GetKitchenObject().itemInfo);
        }
        if (kitchenObject != null)
        {
            counterIcon.sprite = null;
        }
    }
    public void HoverOn(Player player)
    {
        isSelected?.Enable();
        if (kitchenObject == null)
        {
            if (player.GetKitchenObject() != null)
            {
                counterIcon.sprite = player.GetKitchenObject().itemInfo.sprite;
            }
            else if (player.itemSelected != null)
            {
                counterIcon.sprite = player.itemSelected.sprite;
            }
            else
            {
                counterIcon.sprite = defaultSprite;
            }
        }
    }

    public void HoverOff(Player player)
    {
        isSelected?.Disable();
        if (kitchenObject == null)
        {
            counterIcon.sprite = defaultSprite;
        }
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoint;
    }
}
