using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopAnimation : MonoBehaviour
{
    [SerializeField] private FloatReference popTime;
    [SerializeField] private FloatReference popSize;

    private float _scaleValue;
    private float _maxScaleValue;
    private float _minScaleValue;

    private void Start()
    {
        StartCoroutine(ShowPopAnimation());
        
        StartCoroutine(HidePop());
    }

    IEnumerator ShowPopAnimation()
    {
        _scaleValue = Mathf.Sqrt(popSize.Value);
        _maxScaleValue = _scaleValue + 0.2f;
        _minScaleValue = _scaleValue - 0.2f;
        
        var targetScale = new Vector3(_maxScaleValue, _maxScaleValue);
        var myTween = transform.DOScale(targetScale, 0.2f);
        yield return myTween.WaitForCompletion();

        targetScale = new Vector3(_minScaleValue, _minScaleValue);
        myTween = transform.DOScale(targetScale, 0.2f);
        yield return myTween.WaitForCompletion();

        targetScale = new Vector3(_scaleValue, _scaleValue);
        myTween = transform.DOScale(targetScale, 0.2f);
        yield return myTween.WaitForCompletion();
    }

    IEnumerator HidePop()
    {
        yield return new WaitForSeconds(popTime.Value);
        transform.DOScale(0, 0.3f);
    }
}
