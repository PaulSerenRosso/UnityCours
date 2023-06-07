using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGeneric : GenericSingleton<AudioManagerGeneric>
{
    [SerializeField]
    private List<float> floatList = new List<float>();

    [SerializeField] private uint seed;
    protected override void Awake()
    {
      //  floatList.SuffleList();
        floatList.Shuffle();
      base.Awake();
       test test = new test(5);
    test newTest =  test.CopyClass();
    Debug.Log(newTest.value);
    Rn.SetSeed(seed);
    for (int i = 0; i < 50; i++)
    {
        Debug.Log(Rn.NextUInt());
    }
    }

    public class test
    {
        public float value;

        public test()
        {
            
        }
        public test(float value)
        {
            this.value = value;
        }
    }


}


