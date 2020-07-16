using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeElementController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI upgradeName;
    [SerializeField] private TextMeshProUGUI currentValue;
    [SerializeField] private TextMeshProUGUI valueToAdd;
    [SerializeField] private Slider progressSlider;

    private string _description;
    private TextMeshProUGUI _descriptionText;
    
    public void SetUpElement(UpgradeData upgradeData, TextMeshProUGUI descText)
    {
        upgradeName.text = upgradeData.GetName();
        currentValue.text = upgradeData.GetVariable().ToString();
        valueToAdd.text = "(+" + upgradeData.GetValueToAdd() + ")";

        _descriptionText = descText;
        _description = upgradeData.GetDescription();
        
        progressSlider.minValue = upgradeData.GetStartValue();
        progressSlider.maxValue = upgradeData.GetMaxValue();
        progressSlider.value = upgradeData.GetVariable();
    }

    public void ShowDescription()
    {
        _descriptionText.text = _description;
    }

    private void Update()
    {
    }
}
