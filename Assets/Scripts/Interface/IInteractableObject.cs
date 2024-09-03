using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Interface
{
    public interface IInteractableObject
    {
        void Interact(Player player);
        void HoverOn(Player player);
        void HoverOff(Player player);
    }
}
