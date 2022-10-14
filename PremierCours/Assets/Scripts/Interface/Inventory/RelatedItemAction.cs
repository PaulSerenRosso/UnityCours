
    using UnityEngine;

    public class RelatedItemAction : IUsable, IRelatable
    {
        public void Use()
        {
            Relate();
        }

        public void Relate()
        {
            Debug.Log("Relate Story");
        }
    }

