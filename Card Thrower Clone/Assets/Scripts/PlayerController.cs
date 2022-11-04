using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
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
        Update();
    }

    private void PlayerMovement()
    {
        if(GameManager.instance.gameStart)
        {
            transform.Translate(Vector3.forward * GameManager.instance.temporarySpeed * Time.deltaTime);
        }  
    }
}
