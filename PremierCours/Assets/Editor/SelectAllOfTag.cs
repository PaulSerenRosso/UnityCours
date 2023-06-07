using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectAllOfTag : ScriptableWizard
{
    public string searchTag = "your tag here";

    [MenuItem("Supinfogame/Select all of Tag")]
    public static void SelectAllOfTagWizard()
    {
        ScriptableWizard.DisplayWizard<SelectAllOfTag>("Select all of Tag", "Make Selection");
    }

    private void OnWizardCreate()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(searchTag);
        Selection.objects = gameObjects;
    }
}
