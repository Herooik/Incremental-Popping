using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnStartBall : MonoBehaviour
{
    [SerializeField] private GameObject startBall;

    private bool _isSpawned;

    private void OnEnable()
    {
        _isSpawned = false;
    }

    private void Update()
    {
        //CheckForInputTouch();

        CheckForMouseInput();
    }

    private void CheckForMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && !_isSpawned /* && !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId) */)
        {
            var spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0;

            SpawnBall(spawnPosition);
            
            this.enabled = false;
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
        Instantiate(startBall, pos, Quaternion.identity);

        _isSpawned = true;
    }
        
}
