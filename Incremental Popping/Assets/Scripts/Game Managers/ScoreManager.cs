using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    
    [SerializeField] private IntReference roundScore;
    [SerializeField] private IntReference allScore;
    [SerializeField][Range(0,5f)] private float pauseTimeAfterEndRound = 2f;
    [SerializeField][Range(0,5f)] private float pauseTimeAfterScoreSummary = 2f;
    
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

    public void AddRoundScoreToAllScore()
    {
        StartCoroutine(ScoreSummaryCo());
    }

    private IEnumerator ScoreSummaryCo()
    {
        yield return new WaitForSeconds(pauseTimeAfterEndRound);

        if (roundScore.Value != 0)
        {
            var amountToAddToAllScore = allScore.Value + roundScore.Value;
            DOTween.To(() => roundScore.Value, x => roundScore.Value = x, 0, 1);
            var allScoreTween = DOTween.To(() => allScore.Value,
                x => allScore.Value = x, amountToAddToAllScore, 1);

            yield return allScoreTween.WaitForCompletion();

            yield return new WaitForSeconds(pauseTimeAfterScoreSummary);
        }

        
        CurtainController.Instance.MoveToTheShop();
    }
}
