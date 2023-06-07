using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using Component = UnityEngine.Component;
using Random = UnityEngine.Random;

public class ShapeManager : MonoBehaviour
{
    [SerializeField] private List<Shape> shapes = new List<Shape>();

    [SerializeField] private List<Cube> cubes;
    [SerializeField] private List<Sphere> spheres;
    [SerializeField] private List<Capsule> capsules ;
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    private List<T> FindAllTypeShape<T>()
    {
        return shapes.OfType<T>().ToList();
    }
    private void Start()
    {

        for (int i = 0; i < 5; i++)
        {
            CreateShape<Cube>();
        }
        
        for (int i = 0; i < 5; i++)
        {
            CreateShape<Capsule>();
        }
        
        for (int i = 0; i < 5; i++)
        {
            CreateShape<Sphere>();
        }

        cubes = FindAllTypeShape<Cube>();
        spheres = FindAllTypeShape<Sphere>();
        capsules = FindAllTypeShape<Capsule>();
      //  DestroyAllObjectsOfType<Cube>();
    }

    void CreateShape<T>() where T : Shape
    {
        GameObject newGo = new GameObject();
//        Debug.Log($"{typeof(T)}");
        T shape = newGo.AddComponent<T>();
   MeshCollider meshCollider=     newGo.AddComponent<MeshCollider>();
        newGo.transform.position = Random.insideUnitSphere * 10;
      MeshFilter meshFilter=  newGo.AddComponent<MeshFilter>();
       MeshRenderer renderer = newGo.AddComponent<MeshRenderer>();
       renderer.material = material;
       meshFilter.mesh = mesh;
       meshCollider.sharedMesh = mesh;
        shapes.Add(shape);
    }
    
    public static class MaClasse 
    { 
        public const string MA_VARIABLE_CONSTANTE = "Ceci est une constante"; 
        public static readonly string MA_VARIABLE_READONLY; 
  
        static MaClasse() 
        { 
            MA_VARIABLE_READONLY = "Ceci est une variable readonly"; 
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        if (isShapeUnderMouse<Cube>())
        {
            Debug.Log("hit cube");
        }
        if (isShapeUnderMouse<Sphere>())
        {
            Debug.Log("hit sphere");
        }
        if (isShapeUnderMouse<Capsule>())
        {
            Debug.Log("hit capsule");
        }
        }
    }

    void DestroyAllObjectsOfType<T>() where T : Component
    {
        T[] components = FindObjectsOfType<T>();
        for (int i = 0; i < components.Length; i++)
        {
            if(Application.isPlaying)
                Destroy(components[i].gameObject);
            else
            DestroyImmediate(components[i].gameObject);
        }
    }

    bool isShapeUnderMouse<T>() where T : Component
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*50, Color.red, 5);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
        Debug.DrawRay(ray.origin, ray.direction*hit.distance, Color.blue, 5);
            if (hit.collider.GetComponent<T>())
            {
                return true; 
            }
        }

        return false;
    }
}