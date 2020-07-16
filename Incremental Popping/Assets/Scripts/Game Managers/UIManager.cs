using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI roundScoreText;
    [SerializeField] private TextMeshProUGUI allScoreText;
    [SerializeField] private IntReference roundScore;
    [SerializeField] private IntReference allScore;
    
    private NumberFormatInfo _numberFormatInfo = new CultureInfo("en-US", false).NumberFormat;
    
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

    private void Start()
    {
        roundScore.Value = 0;
        roundScoreText.text = "+" + roundScore.Value;
        allScoreText.text = "$" + allScore.Value;
    }

    private void Update()
    {
        roundScoreText.text = roundScore.Value.ToString("C0", _numberFormatInfo);
        allScoreText.text = allScore.Value.ToString("C0", _numberFormatInfo);
    }
}
