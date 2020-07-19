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
    [SerializeField] private Button buyButton;

    private UpgradeData _upgradeDataRef;
    private string _description;
    private TextMeshProUGUI _descriptionText;
    private BuyButtonHandler _buyButtonHandler;

    public void SetUpElement(UpgradeData upgradeData, TextMeshProUGUI descText, List<Button> buttonList)
    {
        _upgradeDataRef = upgradeData;
        
        upgradeName.text = _upgradeDataRef.GetName();
        currentValue.text = _upgradeDataRef.GetVariable().ToString();
        valueToAdd.text = "(+" + _upgradeDataRef.GetValueToAdd() + ")";

        _descriptionText = descText;
        
        progressSlider.minValue = _upgradeDataRef.GetStartValue();
        progressSlider.maxValue = _upgradeDataRef.GetMaxValue();
        progressSlider.value = _upgradeDataRef.GetVariable();
        
        SetBuyButton(_upgradeDataRef);

        buttonList.Add(buyButton);
    }

    private void SetBuyButton(UpgradeData upgradeData)
    {
        _buyButtonHandler = buyButton.GetComponent<BuyButtonHandler>();
        
        _buyButtonHandler.UpgradeDataRef = upgradeData;
        _buyButtonHandler.ProgressSlider = progressSlider;
        _buyButtonHandler.IsButtonChecked = true;
    }

    public void ShowDescription()
    {
        _descriptionText.text = _upgradeDataRef.GetDescription();
    }
}
