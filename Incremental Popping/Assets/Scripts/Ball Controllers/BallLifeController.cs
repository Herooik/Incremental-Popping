using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLifeController : MonoBehaviour
{
    [SerializeField] private FloatReference popTime;
    [SerializeField] private IntReference popSize;
    [SerializeField] private CircleCollider2D thisCollider;
    [SerializeField] private Animation animation;
    [SerializeField] private AnimationClip[] clips;

    private List<AnimationCurve> _curves = new List<AnimationCurve>();
    private float _scaleValue;
    private float _maxScaleValue;
    private float _minScaleValue;

    private void Start()
    {
        SetAnimations();
        
        PlayShowAnimation();

        StartCoroutine(Hide());
    }

    private void SetAnimations()
    {
        _scaleValue = Mathf.Sqrt(popSize.Value);
        _maxScaleValue = _scaleValue + 0.2f;
        _minScaleValue = _scaleValue - 0.2f;
        
        var curve = AnimationCurve.Linear(0, 1, 0.3f, _maxScaleValue);
        var curve1 = AnimationCurve.Linear(0, _maxScaleValue, 0.3f, _minScaleValue);
        var curve2 = AnimationCurve.Linear(0, _minScaleValue, 0.3f, _scaleValue);
        var curve3 = AnimationCurve.Linear(0, _scaleValue, 0.5f, 0);

        _curves.Add(curve);
        _curves.Add(curve1);
        _curves.Add(curve2);
        _curves.Add(curve3);

        for (int i = 0; i < clips.Length; i++)
        {
            clips[i].legacy = true;
            clips[i].SetCurve("", typeof(Transform), "localScale.x", _curves[i]);
            clips[i].SetCurve("", typeof(Transform), "localScale.y", _curves[i]);
        }
    }

    private void PlayShowAnimation()
    {
        animation.PlayQueued("Show1", QueueMode.CompleteOthers);
        animation.PlayQueued("Show2", QueueMode.CompleteOthers);
        animation.PlayQueued("Show3", QueueMode.CompleteOthers);
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(popTime.Value);

        thisCollider.enabled = false;
        animation.PlayQueued("Hide", QueueMode.CompleteOthers);
    }
}
