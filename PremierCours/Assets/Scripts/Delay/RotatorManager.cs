using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RotatorManager : MonoBehaviour
{

    [SerializeField] private Transform[] transforms;

    [SerializeField] private float speed = 150;
    private void Start()
    {
        BeginRotateShapes();
    }

    private void BeginRotateShapes()
    {
        for (int i = 0; i < transforms.Length; i++)
        {
            RotateForSeconds(transforms[i], 1+i);
        }
    }

    async void RotateForSeconds(Transform tr, float duration)
    {
        float end = Time.time + duration;
        while (Time.time < end)
        {
            tr.Rotate(new Vector3(1,1)*Time.deltaTime*speed);
            await Task.Yield();
        }
    }
}
