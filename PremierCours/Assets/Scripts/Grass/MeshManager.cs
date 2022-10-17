using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshManager : MonoBehaviour
{
    [SerializeField] private Vector3[] verts;

    [SerializeField] private int[] tris;

    [SerializeField] private MeshFilter meshFilter;
    
    // blendshape check 
    /* bounds définir à quelle point
     une vertices est visible par 
     la camera donc une boite si 
     la camera elle commence à 
     voir cette boite alors on rend visible l'objet*/
  private void Start()
  {
      Mesh mesh = new Mesh();
      mesh.vertices = verts;
      mesh.triangles = tris;
      meshFilter.mesh = mesh;
      mesh.RecalculateBounds();
      mesh.RecalculateNormals();
      mesh.RecalculateTangents();

  }
}
