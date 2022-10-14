using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class UIMouseOver : MonoBehaviour,
     IPointerEnterHandler
    , IPointerExitHandler
{
    public void Initialize(UnityEvent _onPointerEnterEvent, UnityEvent _onPointerExitEvent)
    {
        onPointerEnterEvent = _onPointerEnterEvent;
        onPointerExitEvent = _onPointerExitEvent;
    }
    [SerializeField]
    private UnityEvent onPointerEnterEvent;
    [SerializeField]
    private UnityEvent onPointerExitEvent;
    public void OnPointerEnter(PointerEventData eventData)
    { 
        onPointerEnterEvent?.Invoke();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        onPointerExitEvent?.Invoke();
    }
}
