using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SmallBallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private float movementSpeed = 3f;

    private Vector3 _lastVelocity;

    void Start()
    {
        var xDir = Random.Range(-1f, 1f);
        var yDir = Random.Range(-1f, 1f);
        ballRigidbody.AddForce(new Vector2(xDir, yDir));
    }
    
    void FixedUpdate()
    {
        ballRigidbody.velocity = ballRigidbody.velocity.normalized * movementSpeed;
        _lastVelocity = ballRigidbody.velocity;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var speed = _lastVelocity.magnitude;
        var direction = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal);

        ballRigidbody.velocity = direction * speed;
    }
}
