using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIinput : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public GameData data;
    public Transform playerTransform;
    public bool firstTouch = false;

    public void OnDrag(PointerEventData eventData)
    {
        if (firstTouch)
        {
            Vector3 temporaryPos = playerTransform.position;
            temporaryPos.x = Mathf.Clamp(temporaryPos.x + eventData.delta.x * data.swipeSpeed, -1.8f, 1.8f);
            playerTransform.position = temporaryPos;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        firstTouch = true;
        GameManager.instance.gameStart = true;
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnStart, OnStart);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnStart, OnStart);
    }
    private void OnStart()
    {
        firstTouch = true;
        EventManager.BroadCast(GameEvent.OnStart);
        Debug.Log("Input onstart çalıştı");
    }


}
