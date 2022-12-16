using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multicast : MonoBehaviour
{

    delegate  void MultiEffect();

    private MultiEffect multiEffect;
    [SerializeField] private Transform target; 
    // Start is called before the first frame update
    void Start()
    {
        multiEffect += PowerUp;
        multiEffect += TurnRed;
        multiEffect();
    }
    
    void PowerUp()
    {
        target.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
    }

    void TurnRed()
    {
        target.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    // Update is called once per frame

}
