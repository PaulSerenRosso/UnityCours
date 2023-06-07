using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeController : MonoBehaviour
{
 

    [SerializeField]
    private float slowDownFactor = 0.05f;

    [SerializeField] private float slowDownDuration = 2f;
    [SerializeField] private KeyCode slowDownKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(slowDownKey))
        {
            DoSlowDown();
        }
        if(Input.GetKeyUp(slowDownKey))
        {
            RevertSlowDown();
        }
    }

    private void RevertSlowDown()
    {
        Time.timeScale = 1f / slowDownDuration*Time.unscaledDeltaTime;

        Time.fixedDeltaTime = 0.02f;
    }

    private void DoSlowDown()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f; 
        
    }
}
