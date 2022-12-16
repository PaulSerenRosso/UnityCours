using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncTest : MonoBehaviour
{
    private Func<string> myFunction;
    // Start is called before the first frame update

    void Start()
    {
        myFunction += ReturnHello;
        Debug.Log(myFunction?.Invoke());
        List<int> elements = new List<int>() { 10, 11, 15, 6, 5 };
        int oldIndex = elements.FindIndex(x => x % 2 != 0);
        Debug.Log(oldIndex);
        Func<int, int> Func1 = x => x + 1;
        Debug.Log("Func1" + Func1.Invoke(200));

        Func<int, int> bonsoir = (x) => { return x + 1; };

        Action spawn = () => Debug.Log("hi");
        spawn?.Invoke();

        // spawn = delegate { ()=>{} };


        Predicate<int> predicate = _i => _i == 5;
        Debug.Log(predicate.Invoke(4));
        Debug.Log(predicate.Invoke(5));
        Func<int, int>[] lookup = 
        {
            a => a + 100, a => a + 200, a => a + 300
        };
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(lookup[i%3](i));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    string ReturnHello()
    {
        return "Hello";
    }
}