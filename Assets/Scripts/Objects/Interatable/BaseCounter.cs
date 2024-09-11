using Assets.Interface;
using Assets.Scripts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects.Interatable
{
    public abstract class BaseCounter : MonoBehaviour, IInteractableObject, IKitchenObjectParent
    {
        [SerializeField]
        private ClearCounterSelected isSelected;
        [SerializeField]
        private Transform spawnPoint;
        private KitchenObject kitchenObject;
        public void HoverOn(Player player)
        {
            isSelected?.Enable();
        }
        public void HoverOff(Player player)
        {
            isSelected?.Disable();
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

        public bool HasKitchenObject()
        {
            return kitchenObject != null;
        }
        public abstract void Interact(Player player);
    }
}
