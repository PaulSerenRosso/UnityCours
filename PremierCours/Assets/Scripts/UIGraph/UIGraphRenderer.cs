using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIGraphRenderer : Graphic
{
    public List<float> points; 
    [SerializeField] private float thickness = 1;
    private Vector3 offset;
    private float height;
    private float width;

    [SerializeField] private TextMeshProUGUI currentValueText;
    [SerializeField] private TextMeshProUGUI maxValueText;
    [SerializeField] private TextMeshProUGUI minValueText;
    
    UIVertex vert = UIVertex.simpleVert;
    private Quaternion rot;
    private Vector2 p1;
    private Vector2 p2;
    private float angle;
    private float unitWidth;
    private float unitHeight;
    [SerializeField]
    private int maxPoint = 10;

    private float scale;
    private float maxValue;
    private float minValue;
    private float newMaxValue;
    float GetMaxValue()
    {
         newMaxValue = 0;
         foreach (var point in points)
         {
            if (newMaxValue < point)
            {
                newMaxValue = point;
            }
         }
         return newMaxValue;
    }
    private float newMinValue;
    float GetMinValue()
    {
        newMinValue = int.MaxValue;
        foreach (var point in points)
        {
            if (newMinValue > point)
            {
                newMinValue = point;
            }
        }
        return newMaxValue;
    }
    protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            if (points.Count < 2)
            {
                return;
            }
            Rescale();
            for (int i = 0; i < points.Count-1; i++)
            {
                p1.x = i;
                p1.y = points[i];
                p2.x = i + 1;
                p2.y = points[i + 1];
                AddSegment(p1,p2, i, vh);
            }
        }

    void Rescale()
    {

        var rect = rectTransform.rect;
        height = rect.height;
        width = rect.width;
        RefreshTextValues();
        scale = Mathf.Clamp(maxValue - minValue, 0.1f, int.MaxValue);
        offset = new Vector2(width*0.5f,height * 0.5f);
        unitWidth = width / maxPoint;
        unitHeight = height / scale;

    }

    private void RefreshTextValues()
    {
        if (maxPoint != GetMaxValue())
        { 
            maxValue = newMaxValue;
            maxValueText.text = Mathf.RoundToInt(maxValue).ToString();
            maxValueText.ForceMeshUpdate(true);
        }

        if (minValue != GetMinValue())
        {
            minValue = newMinValue;
            minValueText.text = Mathf.RoundToInt(minValue).ToString();
            minValueText.ForceMeshUpdate(true);
        }
        currentValueText.text = Mathf.RoundToInt(points[points.Count - 1]).ToString("f2");
        currentValueText.ForceMeshUpdate(true);
        currentValueText.rectTransform.anchoredPosition = new Vector2(
            currentValueText.rectTransform.anchoredPosition.x, (points[points.Count - 1] - minValue)
            * unitHeight - height);
    }

    void AddSegment(Vector2 _point1, Vector2 _point2, int index, VertexHelper _vh)
    {
        vert.color = color; 
        angle = Mathf.Atan2((_point2.y - _point1.y)*unitHeight, (_point2.x - _point1.x)*unitWidth)*Mathf.Rad2Deg;
        rot = Quaternion.Euler(0, 0, angle);
        vert.position = rot * new Vector3(0, -thickness *0.5f)+new Vector3(_point1.x*unitWidth, (_point1.y-minValue)*unitHeight)-offset;
        _vh.AddVert(vert);
        
        vert.position = rot * new Vector3(0, thickness *0.5f)+new Vector3(_point1.x*unitWidth, (_point1.y-minValue)*unitHeight)-offset;
        _vh.AddVert(vert);
        
        vert.position = rot * new Vector3(0, -thickness *0.5f)+new Vector3(_point2.x*unitWidth, (_point2.y-minValue)*unitHeight)-offset;
        _vh.AddVert(vert);
        
        vert.position = rot * new Vector3(0, thickness *0.5f)+new Vector3(_point2.x*unitWidth, (_point2.y-minValue)*unitHeight)-offset;
        _vh.AddVert(vert);

        int amount = index * 4;
        if (index > 0)
        {
           _vh.AddTriangle(3+(index-1)*4,2+(index-1)*4,0+amount);
           _vh.AddTriangle(3+(index-1)*4,2+(index-1)*4,amount+1);
        }
        _vh.AddTriangle(amount,amount+1,amount+3);
        _vh.AddTriangle(amount+3,amount+2,amount);
    }

    public void AddPoint(float point)
    {
        if (points.Count > maxPoint)
        {
            points.RemoveAt(0);
        }
        points.Add(point);
       
    }
}
