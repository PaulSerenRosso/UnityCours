using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIRectRenderer : Graphic
{
    [SerializeField] private float thickness = 1;
    private float width;
    private float height;
    private Vector3 offset;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            var rect = rectTransform.rect;
            height = rect.height;
            width = rect.width;
            offset.x = width/2;
            offset.y = height / 2;
            DrawLines(vh);
        }

        void DrawLines(VertexHelper _vh)
        {
            UIVertex[] vertices = new UIVertex[16];
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = UIVertex.simpleVert;
                vertices[i].color = color;
            }
            vertices[0].position = new Vector3(-thickness,  -thickness)-offset;
            vertices[1].position = new Vector3(thickness,  -thickness)-offset;
            vertices[2].position = new Vector3(-thickness,  height+thickness)-offset;
            vertices[3].position = new Vector3(thickness,  height+thickness)-offset;
            
            vertices[4].position = new Vector3(-thickness+width,  -thickness)-offset;
            vertices[5].position = new Vector3(thickness+width,  -thickness)-offset;
            vertices[6].position = new Vector3(-thickness+width,  height+thickness)-offset;
            vertices[7].position = new Vector3(thickness+width,  height+thickness)-offset;
           
            vertices[8].position = new Vector3(-thickness,  -thickness)-offset;
            vertices[9].position = new Vector3(-thickness,  +thickness)-offset;
            vertices[10].position = new Vector3(thickness+height,  -thickness)-offset;
            vertices[11].position = new Vector3(thickness+height,  thickness)-offset;
            
            vertices[12].position = new Vector3(-thickness,  -thickness+width)-offset;
            vertices[13].position = new Vector3(-thickness,  thickness+width)-offset;
            vertices[14].position = new Vector3( height+thickness,  -thickness+width)-offset;
            vertices[15].position = new Vector3(height+thickness,   thickness+width)-offset;
            
            for (int i = 0; i < vertices.Length; i++)
            {
            _vh.AddVert(vertices[i]);
            }
            _vh.AddTriangle(0,1,3);
            _vh.AddTriangle(0,3,2);
            _vh.AddTriangle(4,5,7);
            _vh.AddTriangle(4,7,6);
            
            _vh.AddTriangle(8,9,11);
            _vh.AddTriangle(8,11,10);
            _vh.AddTriangle(12,13,15);
            _vh.AddTriangle(12,15,14);
        }
    }
