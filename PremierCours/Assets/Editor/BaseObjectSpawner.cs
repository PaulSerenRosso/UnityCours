using System;
using UnityEditor;
using UnityEngine;

public class BasicObjectSpawner : EditorWindow
{
    string objectBaseName;
    int objectID = 1;
    float objectScale = 1f;
    float spawnRadius = 5f;
    GameObject objectToSpawn;

    private bool objectToSpawnIsNull = false;
    [MenuItem("Supinfogame/Basic object Spawner")]
    public static void ShowWindow()
    {
        GetWindow(typeof(BasicObjectSpawner));
    }

    void OnGUI()
    {
        GUILayout.Label("Spawn New Object", EditorStyles.boldLabel);
        objectBaseName = EditorGUILayout.TextField("Object Name", objectBaseName);
        objectID = EditorGUILayout.IntField("Object ID  ", objectID);
        objectScale = EditorGUILayout.FloatField("Object Scale", objectScale);
        spawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawnRadius);
        objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;
        if (objectToSpawn == null)
        {

            objectToSpawnIsNull = true;
            GUI.enabled = false;
        }
        else objectToSpawnIsNull = false;

        if (GUILayout.Button("Spawn Object"))
            {
                SpawnObject();
            }
        if (objectToSpawnIsNull)
        {
            GUI.enabled = true;
        }

    }

    private void SpawnObject()
    {
     
    }
}