using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericClassExample : MonoBehaviour,GenericClass<float>
{
    public float item { get; }
    public void UpdateItem(float newItem)
    {
        Debug.Log(newItem);
    }

    private void Start()
    {
        UpdateItem(210);
    }
}
