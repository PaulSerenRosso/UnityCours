using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFixedUpdateWithoutDeltatime : MonoBehaviour
{
    [SerializeField]
    float speed;

    private float t; 
    // Update is called once per frame
    void Update()
    {
        t += speed; 
        transform.position = new Vector3(transform.position.x , Mathf.PingPong(t, 10 ));
    }
}
