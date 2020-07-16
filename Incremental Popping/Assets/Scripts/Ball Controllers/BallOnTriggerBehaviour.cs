using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallOnTriggerBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private CircleCollider2D thisCircleCollider2D;
    [SerializeField] private SpriteRenderer thisSpriteRenderer;
    [SerializeField] private Canvas ballCanvas;
    [SerializeField] private BallValueController ballValueController;
    [SerializeField] private PopAnimation popAnimation;
    [SerializeField] private PopCountController popCountController;

    private bool _isBallTouched;
    private float _scaleValue;

    private static int _layerNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isBallTouched)
        {
            ChangeLayers(other);
            
            SetBallValue(other);
            
            ballRigidbody.velocity = Vector2.zero;

            popAnimation.enabled = true;
            popCountController.enabled = true;

            thisCircleCollider2D.isTrigger = true;
            
            _isBallTouched = true;
        }
    }

    private void ChangeLayers(Collider2D other)
    {
        gameObject.layer = LayerMask.NameToLayer("Big Ball");

        _layerNumber += 1;
        thisSpriteRenderer.sortingOrder = _layerNumber;

        ballCanvas.sortingOrder = thisSpriteRenderer.sortingOrder;
        ballCanvas.gameObject.SetActive(true);
    }

    private void SetBallValue(Collider2D other)
    {
        var touchedBall = other.GetComponent<BallValueController>();

        var newValue = touchedBall.GetValue();
        ballValueController.SetValue(newValue);
    }
}
