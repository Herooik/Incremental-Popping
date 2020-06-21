using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallValueController : MonoBehaviour
{
    [SerializeField] private FloatReference multiplier;
    [SerializeField] private int value = 10;
    [SerializeField] private TextMeshProUGUI valueText;

    private void Start()
    {
        valueText.text = value.ToString();
    }

    public float GetValue()
    {
        return value * multiplier.Value;
    }

    public void SetValue(float newValue)
    {
        value = (int)newValue;
        valueText.text = value.ToString();
    }
}
