using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Lever :  MonoBehaviour,IInteractable
{
    public void Interact()
    {
      Debug.Log("open Door");
    }
}
// dans les objets j'ai des conssomables des objets qui sont équipable et j'ai des objets quete un objet peut avoir plusierus interfaces il y a qu'une seul liste
// on veut pouvoir avoir les objets avec l'index
// et il affiche ce que je peux faire des boutons
// touche item ça selectionne un item