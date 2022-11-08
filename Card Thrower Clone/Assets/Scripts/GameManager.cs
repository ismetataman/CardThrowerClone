using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData data;
    public bool gameStart = false;

    [Header("Card Settings")]
    public float temporaryThrowRate;
    public float temporaryCardRange;
    public bool canSpreadShot;
    public bool canDualShot;
    public float cardCoolDown;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        temporaryThrowRate = data.throwRate;
        temporaryCardRange = data.cardRange;
        canSpreadShot = data.spreadShot;
        canDualShot = data.dualShot;
        cardCoolDown = temporaryThrowRate;
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnStart, OnStart);
        EventManager.AddHandler(GameEvent.OnThrowRate, OnThrowRate);
        EventManager.AddHandler(GameEvent.OnCardRange, OnCardRange);
        EventManager.AddHandler(GameEvent.OnSpreadShot, OnSpreadShot);
        EventManager.AddHandler(GameEvent.OnDualShot, OnDualShot);
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnStart, OnStart);
        EventManager.RemoveHandler(GameEvent.OnThrowRate, OnThrowRate);
        EventManager.RemoveHandler(GameEvent.OnCardRange, OnCardRange);
        EventManager.RemoveHandler(GameEvent.OnSpreadShot, OnSpreadShot);
        EventManager.RemoveHandler(GameEvent.OnDualShot, OnDualShot);
    }

    private void OnStart()
    {
        gameStart = true;
        Debug.Log("GameManeger OnStart");
    }
    private void OnThrowRate()
    {
        temporaryThrowRate -= 0.2f;
        Debug.Log(temporaryThrowRate);
    }
    private void OnCardRange()
    {
        temporaryCardRange += 1f;
    }

    private void OnSpreadShot()
    {
        canSpreadShot = true;
    }

    private void OnDualShot()
    {
        canDualShot = true;
    }



}
