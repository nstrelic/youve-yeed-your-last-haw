using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public Animator animator;

    void OnStart()
    {
        animator.SetTrigger("Idle");
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetTrigger("Highlight");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetTrigger("Idle");
    }
    
    public void OnSelect(BaseEventData eventData)
    {
        animator.SetTrigger("Highlight");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        animator.SetTrigger("Idle");
    }
}
