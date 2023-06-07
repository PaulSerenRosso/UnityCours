using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConstraintExample : MonoBehaviour 
{

    private void Start()
    {
        test<enumtest>();
        
    }

    enum enumtest
    {
        test1, test2, test3
    }
    void test<T>()where T : System.Enum
    {
      var values =  Enum.GetValues(typeof(T));
      foreach (var value in values)
      {
          Debug.Log(Enum.GetName(typeof(T),value));
      }
      
    }
}
