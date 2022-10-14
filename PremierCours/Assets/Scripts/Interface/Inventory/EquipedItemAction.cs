
    using UnityEngine;

    public  class EquipedItemAction : IUsable, IEquipable
    {
        public void Use()
        {
            Equip();
        }

        public void Equip()
        {
            Debug.Log("Equip Item");
        }
    }

