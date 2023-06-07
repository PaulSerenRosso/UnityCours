using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyWindow : EditorWindow
{
 [MenuItem("Windodfsw/My Window")]
 public static void ShowWindow()
 {
  GetWindow(typeof(MyWindow));
 }

 
 void OnGUI()
 {
  
  GUILayout.Label("base Settings", EditorStyles.boldLabel);
 }
}
