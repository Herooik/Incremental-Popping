using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallOnTriggerBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private CircleCollider2D thisCircleCollider2D;
    [SerializeField] private SpriteRenderer thisSpriteRenderer;
    [SerializeField] private Canvas canvas;
    [SerializeField] private IntReference popSize;
    [SerializeField] private BallValueController ballValueController;
    [SerializeField] private BallLifeController ballLifeController;

    private bool _isBallTouched;
    private float _scaleValue;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _scaleValue = Mathf.Sqrt(popSize.Value);
        transform.localScale = new Vector3(_scaleValue, _scaleValue, 1);
        ballRigidbody.velocity = Vector2.zero;

        if (!_isBallTouched)
        {
            ChangeLayers(other);
            SetBallValue(other);

            ballLifeController.enabled = true;
            
            _isBallTouched = true;
        }

        thisCircleCollider2D.isTrigger = true;
    }

    private void ChangeLayers(Collider2D other)
    {
        gameObject.layer = LayerMask.NameToLayer("Big Ball");

        var currentBallOrderLayer = other.GetComponent<SpriteRenderer>().sortingOrder;
        thisSpriteRenderer.sortingOrder = currentBallOrderLayer + 1;

        canvas.sortingOrder = thisSpriteRenderer.sortingOrder;
        canvas.gameObject.SetActive(true);
    }

    private void SetBallValue(Collider2D other)
    {
        var touchedBall = other.GetComponent<BallValueController>();

        var newValue = touchedBall.GetValue();
        ballValueController.SetValue(newValue);
    }
}
