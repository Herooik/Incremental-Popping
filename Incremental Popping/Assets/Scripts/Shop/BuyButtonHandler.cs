using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonHandler : MonoBehaviour
{
    public bool IsButtonChecked { get; set; }
    public UpgradeData UpgradeDataRef { get; set; }
    public Slider ProgressSlider { get; set; }
    
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite activeImage;
    [SerializeField] private Sprite disableImage;
    [SerializeField] private Button thisButton;
    [SerializeField] private IntReference allScore;
    
    private bool _canBuy;

    private void OnEnable()
    {
        if (IsButtonChecked)
        {
            CheckIfCanBuy();
        }
    }

    public void CheckIfCanBuy()
    {
        if (allScore.Value >= UpgradeDataRef.GetUpgradeCost() && !UpgradeDataRef.IsMaxUpgrade())
        {
            PrepareButton(activeImage, true, true);
        }
        else
        {
            PrepareButton(disableImage, false, false);
        }
    }

    private void PrepareButton(Sprite image, bool isInteractable, bool canBuy)
    {
        buttonImage.sprite = image;
        thisButton.interactable = isInteractable;

        _canBuy = canBuy;
    }

    public void CanBuyUpgrade()
    {
        if (_canBuy)
        {
            allScore.Value -= (int) UpgradeDataRef.GetUpgradeCost();
            UpgradeDataRef.UpgradeValue();
            ProgressSlider.value = UpgradeDataRef.GetVariable();

            UpgradeWindowManager.Instance.CheckIfButtonsCanBuy();
        }
    }
}
