using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("cant interact");
    }
}
