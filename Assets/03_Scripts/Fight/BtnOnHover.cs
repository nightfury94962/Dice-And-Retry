using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void Event();

    public Event OnEnter;
    public Event OnExit;

    public void OnPointerEnter(PointerEventData eventData)
	{
        OnEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
	{
        OnExit?.Invoke();
    }
}
