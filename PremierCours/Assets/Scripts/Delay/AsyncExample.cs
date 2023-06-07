using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncExample : MonoBehaviour
{

    [SerializeField] private int value;
    async void DelayedStart()
    {
        await Task.Delay(value);
        if(Application.isPlaying)
        Debug.Log("bonsoir");


    }
}
