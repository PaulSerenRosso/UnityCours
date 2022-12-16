using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameEvent;

    private void Start()
    {
        gameEvent.Raise();
    }
}
