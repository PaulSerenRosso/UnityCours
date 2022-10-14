using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioManager.PlayWithKey(AudioManager.SoundEnum.Select);
        }
    }
}
