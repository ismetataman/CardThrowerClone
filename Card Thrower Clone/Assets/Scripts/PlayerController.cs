using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameData data;
    public Animator anim;
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
        anim.SetBool("RunAndThrow", true);
    }

    private void PlayerMovement()
    {
        if (GameManager.instance.gameStart)
        {
            transform.Translate(Vector3.forward * data.speed * Time.deltaTime);
        }
    }
}
