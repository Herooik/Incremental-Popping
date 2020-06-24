using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SmallBallSpawnManager : MonoBehaviour
{
    public static SmallBallSpawnManager Instance { get; private set; }
    
    [SerializeField] private GameObject smallBall;
    [SerializeField] private SpriteRenderer smallBallRenderer;
    [SerializeField] private IntReference amountToSpawn;
    [Header("Spawn Position Range")]
    [SerializeField] [Range(0,8)] private float posX = 8;
    [SerializeField] [Range(0, 3)] private float posY = 3;

    private List<GameObject> _ballsList = new List<GameObject>();

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

    public void SpawnSmallBalls()
    {
        for (int i = 0; i < amountToSpawn.Value; i++)
        {
            var newPosX = Random.Range(-posX, posX);
            var newPosY = Random.Range(-posY, posY);
            smallBallRenderer.color = Random.ColorHSV(0, 1, 0, 1, 0, 1);

            var ball = Instantiate(smallBall);
            ball.transform.position = new Vector2(newPosX, newPosY);
            _ballsList.Add(ball);
        }
    }

    public void DestroyRestBalls()
    {
        foreach (var ball in _ballsList)
        {
            Destroy(ball);
        }
    }
}
