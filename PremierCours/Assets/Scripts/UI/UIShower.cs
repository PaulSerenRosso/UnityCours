using System.Collections.Generic;
using UnityEngine;


public class UIShower : MonoBehaviour
{
    [SerializeField]
    private List<UIShowed> uiShoweds;
    private Dictionary<RectTransform, UIShowed> uiShowedsDictionnary = new Dictionary<RectTransform, UIShowed>(); 
//    [SerializeField] private UnityEvent exitEvent; 
  //  [SerializeField] private UnityEvent enterEvent;
  // c'est chiant de pas savoir d'ou viennent les events 
  private void Start()
  {
      for (int i = 0; i < uiShoweds.Count; i++)
      {
          uiShowedsDictionnary.Add(uiShoweds[i].targetMove, uiShoweds[i]);
      }
  }
  void Update()
    {
        for (int i = 0; i < uiShoweds.Count; i++)
        {
            uiShoweds[i].CheckMousePosition();
        }
    }

    public void BlockToggle(RectTransform transform)
    {
        uiShowedsDictionnary[transform].isLocked = !uiShowedsDictionnary[transform].isLocked;
    }
}
