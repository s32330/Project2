using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public Image Target;
    public Color32 NormalColor;
    public Color32 EnterColor;
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Click");
        }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter");
        Target.color = EnterColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exit");
        Target.color = NormalColor;
    }

   public void Start()
    {
        Target = GetComponent<Image>();
        Target.color = NormalColor;
    }

}
