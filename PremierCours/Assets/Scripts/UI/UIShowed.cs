using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class UIShowed 
{
    public RectTransform detector;
    public RectTransform targetMove;
   public RectTransform startPoint;
   public RectTransform endPoint;

    public bool isLocked;
    public float speed ;
    
    public void CheckMousePosition()
    {
        if (!isLocked)
            {
                if (Ex.InputMouseIsInCanvasArea(detector))
                {
                    Open();
                }
                else
                {
                    Close();
                }
            }
        }

    public void BlockToggle()
    {
        isLocked = !isLocked;
    }
    void Open()
    {
        MoveTo(endPoint.position);
    }

    void Close()
    {
        MoveTo(startPoint.position);
    }
    void MoveTo(Vector3 pos)
    {
        if((pos-targetMove.position).sqrMagnitude >= 0.3f)
        targetMove.position = Vector3.Lerp(targetMove.position, pos, speed*Time.deltaTime);
    }
}
