using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChangerManager : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.onClickEvent += ChangeColor;
        EventManager.testEvent += ChangeColor; 
    }

    private void OnDisable()
    {
        EventManager.onClickEvent -= ChangeColor;
    }

  public  void ChangeColor(Transform tr)
    {
       
        tr.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
}
