using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GrassGenerator : MonoBehaviour
{
// créer un brin d'herbe ou on peut le voir 

// créer un paramètre ou on veut}

    [SerializeField] private MeshFilter meshFilter;




    [SerializeField] private Vector3[] verts;
    [SerializeField] private int[] tris;

    [SerializeField] private Vector2 minGrassScale;
    [SerializeField] private Vector2 maxGrassScale;
   
    [SerializeField] private float brushSize;

    [SerializeField] private Vector2 randomDirection;
    
    [SerializeField]
    private int2 grassMinMaxCount;
    

    
    
    
    
    private void Start()
    {
     
    }




void GenerateGrass(RaycastHit _hit)
{
    transform.position = _hit.transform.position;
    Vector3 normal =  _hit.normal;
        Vector3 tangent =  Vector3.Cross(_hit.normal, Camera.main.transform.up);
        Vector3 biTangent = Vector3.Cross(_hit.normal, tangent);
        Debug.DrawRay(_hit.point, normal, Color.blue, 100);
        Debug.DrawRay(_hit.point, tangent, Color.red, 100);
        Debug.DrawRay(_hit.point, biTangent, Color.green, 100);
        int randomGrassCount = Random.Range(grassMinMaxCount.x, grassMinMaxCount.y);
            Vector3 hitsPositionInSphereSpace = _hit.point-_hit.transform.position;
            /*
        for (int i = 0; i < randomGrassCount; i++)
        {
            float randomDirectionX = Random.Range(-randomDirection.x, randomDirection.x);
            float randomDirectionZ = Random.Range(-randomDirection.x, randomDirection.x);
            Vector3 currentPositionInSphereSpace=  (normal + biTangent * randomDirectionY + tangent * randomDirectionY).normalized * randomSize.y;
        }*/ 
            verts = new Vector3[3];
            Vector3 randomSize = new Vector3(Random.Range(minGrassScale.x, maxGrassScale.x),
                Random.Range(minGrassScale.y, maxGrassScale.y), Random.Range(minGrassScale.x, maxGrassScale.x));

            float randomDirectionX = Random.Range(-randomDirection.x, randomDirection.x);
            float randomDirectionZ = Random.Range(-randomDirection.x, randomDirection.x);
            float randomDirectionY = Random.Range(-randomDirection.y, randomDirection.y);
            verts[0] = (tangent + biTangent * randomDirectionX).normalized * randomSize.x;
            verts[1] = (biTangent + tangent * randomDirectionZ).normalized * randomSize.z;

            verts[2] = (normal + biTangent * randomDirectionY + tangent * randomDirectionY).normalized * randomSize.y;
            for (int i = 0; i < verts.Length; i++)
            {
                verts[i] += hitsPositionInSphereSpace;
            }

            tris = new int[6];
            tris[0] = 0;
            tris[1] = 1;
            tris[2] = 2;
            tris[3] = 0;
            tris[4] = 2;
            tris[5] = 1;
        

        Mesh mesh = new Mesh()
        {
            vertices = verts, triangles = tris
        };
        meshFilter.mesh = mesh;


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000))
            {
                GenerateGrass(hit);
            }
        }
    }
}