using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMethodExample : MonoBehaviour
{
    private void Start()
    { 
        SomeClass someClass =new SomeClass() ;
        Debug.Log((someClass.GenericMethod<float>(5).GetType()));

    }


}
