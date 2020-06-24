using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    
    [SerializeField] private SpawnStartBall spawnStartBall;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SmallBallSpawnManager.Instance.SpawnSmallBalls();
    }

    public void SetGame(bool isActive)
    {
        spawnStartBall.enabled = isActive;

        if (isActive)
        {
            SmallBallSpawnManager.Instance.DestroyRestBalls();
            SmallBallSpawnManager.Instance.SpawnSmallBalls();
        }
        
    }
}
