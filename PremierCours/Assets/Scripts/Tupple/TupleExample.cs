using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TupleExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Tuple<int, string, bool> tuple = new Tuple<int, string, bool>(1, "Cat", true);
        Debug.Log(tuple);
        var result = (count: 10, animal: "duck");
        Debug.Log(result); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    void DesconstructExample()
    {
        var (size, surname) = CarInfo();
        
    }

    (int, string) CarInfo()
    {
        return (10, "Mittens");
    }
}
