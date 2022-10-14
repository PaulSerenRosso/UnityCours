//commenter ses extension methodes qu'on utilise pas 

using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

// un vector tourne dans une direction puis un autre valeur qui peut tourner dans un autre direction 
// mutliplier un vector et un quaternion ce n'est pas permutable
// faire une extension methode qui permet de modifier le lossy scale
// respecter la scale pour que cela soit coherent avec le monde 
// pour la physique car la gravité referenciel va 
//bouger le z n'a pas d'importance en ui
public static class Ex
{
    public static void ResetTransform(Transform _transform)
    {
        _transform.position = Vector3.zero;
        _transform.rotation = quaternion.identity;
        _transform.localScale = Vector3.one;
    }

    public static void SetGlobalScale(this Transform _transform, Vector3 newScale )
    {
        Transform parent = _transform.parent;
        _transform.parent = null;
        _transform.localScale = newScale;
        _transform.parent = parent;
    }
    public static bool InputMouseIsInCanvasArea(RectTransform _canvasArea)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(_canvasArea, Input.mousePosition))
        {
            return true;
        }
        return false;
    }
    
   

 
}
