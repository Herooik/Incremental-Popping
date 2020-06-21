using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SmallBallSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject smallBall;
    [SerializeField] private SpriteRenderer smallBallRenderer;
    [SerializeField] private IntReference amountToSpawn;
    [Header("Spawn Position Range")]
    [SerializeField] [Range(0,8)] private float posX = 8;
    [SerializeField] [Range(0, 3)] private float posY = 3;

    private void Start()
    {
        for (int i = 0; i < amountToSpawn.Value; i++)
        {
            var newPosX = Random.Range(-posX, posX);
            var newPosY = Random.Range(-posY, posY);
            smallBallRenderer.color = Random.ColorHSV(0, 1, 0, 1, 0, 1);

            var ball = Instantiate(smallBall);
            ball.transform.position = new Vector2(newPosX, newPosY);
        }
    }
}
