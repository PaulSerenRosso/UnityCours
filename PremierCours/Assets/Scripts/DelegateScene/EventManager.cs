using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EventManager : MonoBehaviour
{
    public delegate void ClickEvent(Transform tr);

    public static event ClickEvent onClickEvent;

    public delegate void test<T>(T tes);
    public delegate void test1<T>(T tes) where T : struct;
    public delegate G test3<T, G>(T tes, int t = 0 ) where T : class;
    public static event test3<Transform, Vector3> testReturn ;
    public static event test<Transform> testEvent ;
    public static event test<Vector3> vectorEvent;
    public static event test<Color> colorEvent;
    [SerializeField] private System.Reflection.MethodInfo info;

    public Drawing testCustomEvent;
   Transform target;
   [SerializeField]
   private UnityEvent<float, float, float> threeFloatEvent;

   public void funcWithThreeFloat(float a, float b, float c)
   {
       
   }
   [SerializeField] private UnityEvent<TestUnityEventParameter> eventWithCustomParameter;
   [SerializeField]
   private UnityEvent<Transform> testUnityEvent;
   
   private void Start()
   {
       testReturn += (_tes, j) =>
       {
           return new Vector3();
       };

   }

   public void TestCustomParameter(TestUnityEventParameter _testUnityEventParameter)
   {
       Debug.Log(_testUnityEventParameter.name);
   }
   [Serializable]
   public class TestUnityEventParameter
   {
       public string name;
       public int count;
   }
   [Serializable] class floatEvent : UnityEvent<float>
   {
       
   }

   [System.Serializable] public class XYEvent : UnityEvent<float, float, float> { }
 
   [Serializable]
   public class Drawing  // for example, some sort of drawing class
   {
       // step two, have an inspector variable like this:

       public float step;
       public float step2;
       public float step3;
       public XYEvent pointUpdates;

       public void Invoke()
       {
     
           pointUpdates.Invoke(step,step2,step3);
       }
       // in your OTHER class, which RECEIVES the information,
       // simply have a class which takes two floats.
       // drag that other object to this inspector variable.
       
   }
   


   private void Update()
    {
       // info = new System.Reflection.MethodInfo();
      
        if (Input.GetMouseButtonDown(0))
        {
            onClickEvent?.Invoke(target);
            var invocationList = onClickEvent.GetInvocationList();
            for (int i = 0; i < invocationList.Length; i++)
            {
                Debug.Log(invocationList[i].Method.Name);
                Debug.Log(invocationList[i].Method.ReturnType.Name);
                Debug.Log(invocationList[i].Target); 
            }
        }
    }
 


}
