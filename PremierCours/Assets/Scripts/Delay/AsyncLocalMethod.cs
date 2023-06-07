using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class AsyncLocalMethod : MonoBehaviour
{
    void Start()
    {
        BackgroundMethod();
    }

    private async void BackgroundMethod()
    {
        void InnerMethod()
        {
            while (true)
            {
                Thread.Sleep(150);
                Debug.Log("background");
            }
        }

        var task = new Task(() => InnerMethod());
        task.Start();
        await task;
    }
}