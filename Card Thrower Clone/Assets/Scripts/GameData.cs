using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Data",menuName = "Game Data")]
public class GameData : ScriptableObject
{
    [Header("Player Controls")]
    public float speed = 5f;
    public float swipeSpeed = 0.005f;

    [Header("Card Settings")]
    public float throwRate = 0.2f;
    public float cardRange = 1f;
    public bool spreadShot = false;
    public bool dualShot = false;

}
