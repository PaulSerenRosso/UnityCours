using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasttest : MonoBehaviour
{
    [SerializeField] private LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.left, Color.red, 10);
        if (Physics.Raycast(transform.position, Vector3.left, out RaycastHit hit, 5))
        {
            Debug.Log(hit.point);
            Debug.Log("hit");
        }
    }
}