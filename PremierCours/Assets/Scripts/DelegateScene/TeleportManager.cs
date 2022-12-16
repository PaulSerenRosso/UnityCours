using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TeleportManager : MonoBehaviour
{
 [SerializeField] private float radius; 
 void Teleport(Transform tr)
 {
  tr.position = Random.insideUnitSphere*radius;
  
 }

 private void OnEnable()
 {
  EventManager.onClickEvent += Teleport;
 }

 private void OnDisable()
 {
  EventManager.onClickEvent -= Teleport;
 }
}
