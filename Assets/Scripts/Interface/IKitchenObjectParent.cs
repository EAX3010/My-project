using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public interface IKitchenObjectParent
    {
        public KitchenObject GetKitchenObject();
        public bool HasKitchenObject();
        public void SetKitchenObject(KitchenObject kitchenObject);
        public Transform GetSpawnPoint();
    }
}
