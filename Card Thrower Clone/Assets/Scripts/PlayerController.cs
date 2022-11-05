using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameData data;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if(GameManager.instance.gameStart)
        {
            transform.Translate(Vector3.forward * data.speed * Time.deltaTime);
        }  
    }
}
