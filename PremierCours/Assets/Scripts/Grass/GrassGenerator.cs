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
    [SerializeField] private Color[] colorVerts;
    [SerializeField] private int[] tris;

    [SerializeField] private Vector2 minGrassScale;
    [SerializeField] private Vector2 maxGrassScale;
   
    [SerializeField] private float brushSize;

    [SerializeField] private Vector2 randomDirection;
    
    [SerializeField]
    private int2 grassMinMaxCount;
    
void LaunchGrassGeneration(RaycastHit _inputHit)
{
       var inputHitSpace = CreateHitSpace(_inputHit);
        int randomGrassCount = Random.Range(grassMinMaxCount.x, grassMinMaxCount.y);
        DrawHitSpaceRays(_inputHit, inputHitSpace, new []{Color.blue, Color.red, Color.green});
        transform.position = _inputHit.transform.position;
        verts = new Vector3[3*randomGrassCount];
            colorVerts = new Color[3 * randomGrassCount];
            tris = new int[6*randomGrassCount];
    
        GenerateGrass(_inputHit, randomGrassCount, inputHitSpace);
        BuildMesh();
}

private void BuildMesh()
{
    Mesh mesh = new Mesh()
    {
        vertices = verts, triangles = tris, colors = colorVerts
    };
    meshFilter.mesh = mesh;
}

private void GenerateGrass(RaycastHit _inputHit, int _randomGrassCount,
    (Vector3 normal, Vector3 tangent, Vector3 biTangent) _inputHitSpace)
{
    for (int i = 0; i < _randomGrassCount; i++)
    {
        var currentPositionInHitSpace = FindRandomGrassPointInHitSpace(_inputHit, _inputHitSpace);
        Ray rayForFindNewPoint = new Ray(currentPositionInHitSpace, -_inputHitSpace.normal);
        Debug.DrawRay(rayForFindNewPoint.origin, rayForFindNewPoint.direction, Color.black, 100);
        GenerateOneGrass(rayForFindNewPoint, i);
    }
}

private Vector3 FindRandomGrassPointInHitSpace(RaycastHit _inputHit,
    (Vector3 normal, Vector3 tangent, Vector3 biTangent) _inputHitSpace)
{
    float coordinateBiTangent = Random.Range(-1.0f, 1.0f);
    float coordinateTangent = Random.Range(-1.0f, 1.0f);
    Vector3 currentPositionInHitSpace = _inputHit.point +
                                        (_inputHitSpace.biTangent * coordinateBiTangent +
                                         _inputHitSpace.tangent * coordinateTangent).normalized * brushSize;
    return currentPositionInHitSpace;
}

private void GenerateOneGrass(Ray rayForFindNewPoint, int i)
{
    RaycastHit grassHit;
    if (Physics.Raycast(rayForFindNewPoint, out grassHit, 90))
    {
        var grassHitSpace = CreateHitSpace(grassHit);
        DrawHitSpaceRays(grassHit, grassHitSpace, new Color[] { Color.cyan, Color.magenta, Color.yellow });
        var randomSize = GenerateRandomGrassSize();
        var randomDirection = GenerateRandomDirectionGrass();
        SetVertices(i, grassHitSpace, randomDirection, randomSize);
        PlaceTopVertexInHitObjectSpace(i, grassHit);
        SnapBottomVerticesToHitObject(i, grassHit, grassHitSpace);
        CreateTriangle(i);
    }
}

private void PlaceTopVertexInHitObjectSpace(int i, RaycastHit currentHit)
{
    Vector3 currentHitPositionInSphereSpace = currentHit.point - currentHit.transform.position;
    verts[2 + 3 * i] += currentHitPositionInSphereSpace;
    colorVerts[2 + 3 * i] = new Color(1, 1, 1);
}

private Vector3 GenerateRandomGrassSize()
{
    Vector3 randomSize = new Vector3(Random.Range(minGrassScale.x, maxGrassScale.x),
        Random.Range(minGrassScale.y, maxGrassScale.y), Random.Range(minGrassScale.x, maxGrassScale.x));
    return randomSize;
}

private void SetVertices(int i, (Vector3 normal, Vector3 tangent, Vector3 biTangent) grassHitSpace,
    (float tangent, float biTangent, float tangentForNormal, float biTangentForNormal) randomDirection,
    Vector3 randomSize)
{
    verts[0 + 3 * i] = (grassHitSpace.tangent + grassHitSpace.biTangent * randomDirection.biTangent).normalized *
                       randomSize.x;
    verts[1 + 3 * i] = (grassHitSpace.biTangent + grassHitSpace.tangent * randomDirection.tangent).normalized *
                       randomSize.z;
    verts[2 + 3 * i] =
        (grassHitSpace.normal + grassHitSpace.tangent *
            randomDirection.tangentForNormal + grassHitSpace.biTangent * randomDirection.biTangent).normalized *
        randomSize.y;
}

private void SnapBottomVerticesToHitObject(int _i, RaycastHit _currentHit,
    (Vector3 normal, Vector3 tangent, Vector3 biTangent) _grassHitSpace)
{
    for (int j = 3 * _i; j < 2 + 3 * _i; j++)
    {
        colorVerts[j] = new Color(0, 0, 0);
        Ray rayForFindFinalPoint = new Ray(_currentHit.point + verts[j], -_grassHitSpace.normal);
        RaycastHit finalHit;
        if (Physics.Raycast(rayForFindFinalPoint, out finalHit, 90))
        {
            verts[j] = finalHit.point - _currentHit.transform.position;
            Debug.DrawRay(finalHit.point, finalHit.normal, Color.grey, 100);
        }
        Debug.DrawRay(rayForFindFinalPoint.origin, rayForFindFinalPoint.direction, Color.black, 100);
    }
}

private (float tangent, float biTangent,
    float tangentForNormal, float biTangentForNormal) GenerateRandomDirectionGrass()
{
    float randomDirectionBiTangent = Random.Range(-randomDirection.x, randomDirection.x);
   float randomDirectionTangent = Random.Range(-randomDirection.x, randomDirection.x);
    float randomDirectionBiTangentForNormal = Random.Range(-randomDirection.y, randomDirection.y);
    float randomDirectionTangentForNormal = Random.Range(-randomDirection.y, randomDirection.y);
    return (randomDirectionTangent, 
        randomDirectionBiTangent, randomDirectionTangentForNormal, randomDirectionBiTangentForNormal);
}

private void CreateTriangle(int i)
{
    tris[0 + 6 * i] = 0 + 3 * i;
    tris[1 + 6 * i] = 1 + 3 * i;
    tris[2 + 6 * i] = 2 + 3 * i;
    tris[3 + 6 * i] = 0 + 3 * i;
    tris[4 + 6 * i] = 2 + 3 * i;
    tris[5 + 6 * i] = 1 + 3 * i;
}

private void DrawHitSpaceRays(RaycastHit _inputHit,
    (Vector3 normal, Vector3 tangent, Vector3 biTangent) _inputHitSpace, Color[] _rayColors)
{
    Debug.DrawRay(_inputHit.point, _inputHitSpace.normal, _rayColors[0], 100);
    Debug.DrawRay(_inputHit.point, _inputHitSpace.tangent, _rayColors[1], 100);
    Debug.DrawRay(_inputHit.point, _inputHitSpace.biTangent, _rayColors[2], 100);
}

private (Vector3 normal, Vector3 tangent, Vector3 biTangent) CreateHitSpace(RaycastHit _hit)
{
    Vector3 normal = _hit.normal;
    Vector3 tangent = UnityEngine.Vector3.Cross(_hit.normal, Camera.main.transform.up);
    Vector3 biTangent = UnityEngine.Vector3.Cross(_hit.normal, tangent);
    return (normal, tangent, biTangent);
}

private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000))
            {
                LaunchGrassGeneration(hit);
            }
        }
    }
}