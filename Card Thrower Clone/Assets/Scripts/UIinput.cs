using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIinput : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public GameData data;
    public Transform playerTransform;
    private bool clicked = false;

    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.instance.gameStart)
        {
            Vector3 temporaryPos = playerTransform.position;
            temporaryPos.x = Mathf.Clamp(temporaryPos.x + eventData.delta.x * data.swipeSpeed, -1.8f, 1.8f);
            playerTransform.position = temporaryPos;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!clicked)
        {
            clicked = true;
            EventManager.BroadCast(GameEvent.OnStart);
        }
        
    }
    

}
