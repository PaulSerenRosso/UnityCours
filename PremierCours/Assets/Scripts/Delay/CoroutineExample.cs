using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    private Coroutine coroutine;
    private void Start()
    {
        
    }

    public void LaunchCoroutine()
    {
        coroutine =   StartCoroutine(Reload(5));
    }

    public void StopCoroutine()
    { 
        StopCoroutine(coroutine);
    }

    public IEnumerator Reload(float t)
    {
        yield return new WaitForSeconds(t);
    }
}
