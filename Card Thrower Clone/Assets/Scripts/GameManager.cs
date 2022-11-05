using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameData data;
    public bool gameStart = false;
    public float temporarySpeed;
    

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        temporarySpeed = data.speed;
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
        gameStart = true;
        Debug.Log("GameManeger OnStart");
    }

}
