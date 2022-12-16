using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
  public GameEvent gameEvent;
  public UnityEvent onEventRaised;

  public void OnEnable()
  {
      gameEvent.AddListener(this);
  }

  public void OnDisable()
  {
      gameEvent.RemoveListener(this);
  }

  public void OnRaise()
  {
   onEventRaised.Invoke(); 
  }
}
