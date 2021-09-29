using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FloatingJoystick : Joystick
{
    Image overlay; 
    protected override void Start()
    {
        overlay = GetComponent<Image>();
        background.gameObject.SetActive(false);
        base.Start();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        background.gameObject.SetActive(true);
        overlay.CrossFadeAlpha(0,0.2f,false);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        background.gameObject.SetActive(false);
        overlay.CrossFadeAlpha(1,0.2f,false);
        base.OnPointerUp(eventData);
    }
}