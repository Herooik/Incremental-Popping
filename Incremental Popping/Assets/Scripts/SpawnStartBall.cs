using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStartBall : MonoBehaviour
{
    [SerializeField] private GameObject startBall;
    [SerializeField] private IntReference popSize;

    private bool _isSpawned;

    private void Update()
    {
        CheckForInputTouch();

        CheckForMouseInput();
    }

    private void CheckForMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && !_isSpawned)
        {
            var spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0;

            SpawnBall(spawnPosition);
        }
    }

    private void CheckForInputTouch()
    {
        if (Input.touchCount > 0 && !_isSpawned)
        {
            var touch = Input.GetTouch(0);
            var touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                SpawnBall(touchPos);
            }
        }
    }

    private void SpawnBall(Vector3 pos)
    {
        var scaleValue = Mathf.Sqrt(popSize.Value);
        var obj = Instantiate(startBall, pos, Quaternion.identity);
        obj.transform.localScale = new Vector3(scaleValue, scaleValue, 1);
        _isSpawned = true;
    }
}
