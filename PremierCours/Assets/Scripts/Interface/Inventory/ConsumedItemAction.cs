
    using UnityEngine;

    public class ConsumedItemAction : IUsable, IConsumable
    {
        public void Use()
        {
            Consume();
        }

        public void Consume()
        {
            Debug.Log("Consum Item");
        }
    }

