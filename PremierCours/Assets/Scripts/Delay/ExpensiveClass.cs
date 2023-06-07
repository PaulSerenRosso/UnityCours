using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ExpensiveClass : MonoBehaviour
{
 private void Start()
 {
  Debug.Log("Start");
  Example();
 }

 async void Example()
 {
  int t = await Task.Run(() => Allocate());
 }

 private int Allocate()
 {
  int size = 0;

  for (int i = 0; i < 100000; i++)
  {
   size += i;
  }

  return size;
 }

 int GetSum(int count)
 {
  int sum = 0;
  for (int i = 0; i < count; i++)
  {
   sum += (int)Mathf.Pow(i, 2);
  }

  return sum;
 }

 int Negate(Task<int> task)
 {
  return -1 * task.Result;
 }

 async void Run2Methods(int count)
 {
  int result = await Task.Run(() => GetSum(count)).ContinueWith(task => Negate(task));
 }
}
