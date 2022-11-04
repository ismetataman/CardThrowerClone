using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Data",menuName = "Game Data")]
public class GameData : ScriptableObject
{
    [Header("Player Controls")]
    public float speed = 5f;
    public float swipeSpeed = 0.005f;
}
