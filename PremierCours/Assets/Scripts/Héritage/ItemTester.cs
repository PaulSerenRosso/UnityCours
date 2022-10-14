using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Chestplate chestplate = new Chestplate(1, "torse", "une armure", 6,
            10, 20, 10, ItemRaretyEnum.Epic,
            2, 8, 16, 20, 50);
        chestplate.TakeDamage();
        

    }

  
}
