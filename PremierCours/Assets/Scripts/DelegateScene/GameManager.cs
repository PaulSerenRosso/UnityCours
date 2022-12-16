using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public void RestartGame()
  {
    Debug.Log("Restart game");
  }

  private void OnEnable()
  {
    PlayerHealthDelegate.onGameOver += RestartGame;
  }

  private void OnDisable()
  {
    PlayerHealthDelegate.onGameOver -= RestartGame;
  }
}
