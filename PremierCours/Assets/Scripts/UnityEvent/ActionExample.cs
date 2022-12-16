using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionExample : MonoBehaviour
{
    //   public delegate void OnGameOver();

    // public static event OnGameOver onGameOver;
/*
 * namespace System
{
  public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
}

 */
    public static Action<string, int> onGameOver;


    public delegate G test3<T, G>(T tes);

    //lambda 
    private Action SayHello = () => { };

    private test3<StringTest, string> test;

    // public event static Action onGameOver;
    private void OnDestroy()
    {
    }

    public string Test(StringTest a)
    {
        return a.Name += "monstre";
    }

    public string Test2(StringTest b)
    {
        return b.Name += "heho";
    }

    public void ResetGame(string a, int b)
    {
        Debug.Log(a + b);
    }
    // Start is called before the first frame update

    public class StringTest
    {
        public string Name;

        public StringTest(string name)
        {
            Name = name;
        }
    }

    void Start()
    {
        onGameOver += ResetGame;
        onGameOver?.Invoke("bonsoir", 2);

        test += Test;
        test += Test2;

        Debug.Log(test.Invoke(new StringTest("bonsoiraaaa")));
    }

    // Update is called once per frame
    void Update()
    {
    }
}