using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopLifeTime : MonoBehaviour
{
    [SerializeField] private IntReference popCount;
    [SerializeField] private FloatReference popTime;
    [SerializeField] private IntReference popSize;
    [SerializeField] private CircleCollider2D thisCollider;
    
    private float _scaleValue;
    private float _maxScaleValue;
    private float _minScaleValue;

    private void Start()
    {
        popCount.Value++;

        StartCoroutine(ShowPopAnimation());
        
        StartCoroutine(Hide());
    }

    IEnumerator ShowPopAnimation()
    {
        _scaleValue = Mathf.Sqrt(popSize.Value);
        _maxScaleValue = _scaleValue + 0.2f;
        _minScaleValue = _scaleValue - 0.2f;
        
        var targetScale = new Vector3(_maxScaleValue, _maxScaleValue);
        var myTween = transform.DOScale(targetScale, 0.5f);
        yield return myTween.WaitForCompletion();

        targetScale = new Vector3(_minScaleValue, _minScaleValue);
        myTween = transform.DOScale(targetScale, 0.5f);
        yield return myTween.WaitForCompletion();

        targetScale = new Vector3(_scaleValue, _scaleValue);
        myTween = transform.DOScale(targetScale, 0.5f);
        yield return myTween.WaitForCompletion();
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(popTime.Value);
        transform.DOScale(0, 0.5f);

        thisCollider.enabled = false;

        popCount.Value--;
        if (popCount.Value == 0)
        {
            ScoreManager.Instance.AddRoundScoreToAllScore();
        }
    }
}
