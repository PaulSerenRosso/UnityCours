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
            
            verts = new Vector3[3*randomGrassCount];
            tris = new int[6*randomGrassCount];
        for (int i = 0; i < randomGrassCount; i++)
        {
            float coordinateBiTangent = Random.Range(-1.0f, 1.0f);
            float coordinateTangent = Random.Range(-1.0f, 1.0f);
            Vector3 currentPositionInHitSpace= _hit.point+ (biTangent *coordinateBiTangent  + tangent * coordinateTangent).normalized * brushSize;
            RaycastHit currentHit;
            Ray rayForFindNewPoint = new Ray(currentPositionInHitSpace, -normal);
            Debug.DrawRay(rayForFindNewPoint.origin, rayForFindNewPoint.direction, Color.black, 100);
            if (Physics.Raycast(rayForFindNewPoint, out currentHit, 90))
            {
                Vector3 currentHitPositionInSphereSpace = currentHit.point - currentHit.transform.position;
                Vector3 newNormal = currentHit.normal;
                Vector3 newTangent = Vector3.Cross(currentHit.normal, Camera.main.transform.up);
                Vector3 newBiTangent = Vector3.Cross(currentHit.normal, newTangent);
                Debug.DrawRay(currentHit.point, newNormal, Color.cyan, 100);
                Debug.DrawRay(currentHit.point, newTangent, Color.magenta, 100);
                Debug.DrawRay(currentHit.point, newBiTangent, Color.yellow, 100);
                Vector3 randomSize = new Vector3(Random.Range(minGrassScale.x, maxGrassScale.x),
                    Random.Range(minGrassScale.y, maxGrassScale.y), Random.Range(minGrassScale.x, maxGrassScale.x));

                float randomDirectionBiTangent = Random.Range(-randomDirection.x, randomDirection.x);
                float randomDirectionTangent = Random.Range(-randomDirection.x, randomDirection.x);
                float randomDirectionNormal = Random.Range(-randomDirection.y, randomDirection.y);
                verts[0 + 3 * i] = (newTangent + newBiTangent * randomDirectionBiTangent).normalized * randomSize.x;
                verts[1 + 3 * i] = (newBiTangent + newTangent * randomDirectionTangent).normalized * randomSize.z;

                verts[2 + 3 * i] =
                    (newNormal + newBiTangent * randomDirectionNormal + newTangent * randomDirectionNormal).normalized *
                    randomSize.y;
                verts[2 + 3 * i] += currentHitPositionInSphereSpace;
                for (int j = 3 * i; j < 2 + 3 * i; j++)
                {
                    Ray rayForFindFinalPoint = new Ray(currentHit.point + verts[j], -newNormal);
                    Debug.DrawRay(rayForFindFinalPoint.origin, rayForFindFinalPoint.direction, Color.black, 100);
                    RaycastHit finalHit;
                    if (Physics.Raycast(rayForFindFinalPoint, out finalHit, 90))
                    {
                        verts[j] = finalHit.point - currentHit.transform.position;
                        Debug.DrawRay(finalHit.point, finalHit.normal, Color.grey, 100);
                    }
                }
                tris[0 + 6 * i] = 0 + 3 * i;
                tris[1 + 6 * i] = 1 + 3 * i;
                tris[2 + 6 * i] = 2 + 3 * i;
                tris[3 + 6 * i] = 0 + 3 * i;
                tris[4 + 6 * i] = 2 + 3 * i;
                tris[5 + 6 * i] = 1 + 3 * i;
            }
            else
            {
                Debug.Log("c'est la hess");
            }
        }
        

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