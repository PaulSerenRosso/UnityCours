using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;


public class PlaneGenerator : MonoBehaviour
{
    // 
    // continus dynamique besoin qu'un seul rigidbody cela fait gaffe a ce que deux objets se traverse lorsqu'il se déplace
    // continus speculative cela fait gaffe à la rotation des objets 
    // continus faut que les deux objets soient continus 
    // on peut utilsier du perlin noise 3d pour faire des tunels et le perlin noise 2d pour faire du relief
    // les u c'est forcement positif mais il ont une valeur plus grande
    //shader graph y vert rouge x bleu z 
    //objet = local
    // le shader modifie que le visuel de l'objet pas le collider 
 private int verticesRatio = 3;
   [SerializeField] private int resolution = 2;  
   
   [SerializeField]
     private Vector3[] verts;
      [SerializeField]
     private int[] tris;
     [SerializeField]
     private float scale = 5;
     [SerializeField] private MeshFilter meshFilter;
     [SerializeField] private float height = 5;
     [SerializeField] private float perlinScale = 0.3f;
     [SerializeField] private float height2 = 5;
     [SerializeField] private float perlinScale2 = 0.3f;
     [SerializeField] private float scrollField;
     [SerializeField] private float scrollField2;
     [SerializeField] private MeshCollider meshCollider;
     private void Start()
    {
        Init();
    }
     [ContextMenu("Init")]
    void Init()
    {
        verticesRatio = resolution + 1; 
        SetVert();
        // ApplyPerlinNoise();
        SetTris();
        BuildMesh();
    }

    // check les nosie comment ça marche
    // vu que le perlin n'accepte que entre 0 et 1 quand on mets des valeurs négatifs cela donne la symétrie du point positif soit l'opposé

    private void Update()
    {
        
        // Init();
    }


    private void SetVert()
    {
        int vertexIndex = 0;
        verts = new Vector3[verticesRatio*verticesRatio];
        for (int y = 0; y < verticesRatio; y++)
        {
            for (int x = 0; x < verticesRatio; x++)
            {
                verts[vertexIndex] = new float3(x - (verticesRatio-1)*0.5f , 0, y - (verticesRatio-1) *0.5f)* scale;
               // Debug.DrawRay(verts[vertexIndex], Vector3.up, Color.cyan, 10);
                vertexIndex++;
            }
        }
    }
    void ApplyPerlinNoise()
    {
        // de vague sur des vagues deusième perlin noise 
        for (int i = 0; i < verts.Length; i++)
        {
            verts[i].y = Mathf.PerlinNoise((verts[i].x+Time.time*scrollField)*perlinScale+resolution*scale, (verts[i].z+Time.time*scrollField)*perlinScale+resolution*scale)*height+
            Mathf.PerlinNoise((verts[i].x+Time.time*scrollField2)*perlinScale2+resolution*scale, (verts[i].z+Time.time*scrollField2)*perlinScale2+resolution*scale)*height2;
        }
    }
    void SetTris()
    {
      //  resolution*resolution 
      tris = new int[(resolution*resolution)*6];

      int trisIndex = 0;
      for (int x = 0; x < resolution; x++)
      {
          for (int y = 0; y < resolution; y++)
          {
              //first triangle
              tris[trisIndex] = x + y*verticesRatio;
              tris[trisIndex+1] = x + y*verticesRatio+verticesRatio;
              tris[trisIndex+2] = x + y*verticesRatio+1;
              //second triangle
              tris[trisIndex + 3] = x + y*verticesRatio + verticesRatio+1;
              tris[trisIndex + 4] = x + y*verticesRatio + 1;
              tris[trisIndex + 5] = x + y*verticesRatio + verticesRatio;
              trisIndex+=(6);
          }
      }
    }
    public void BuildMesh()
    {
        Mesh mesh = new Mesh()
        {
            vertices = verts, 
            triangles = tris,
        };
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }
}
