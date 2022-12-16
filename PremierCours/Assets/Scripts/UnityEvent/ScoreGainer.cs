using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGainer : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScoreManager.instance.Score += 10;
        }
    }
}
