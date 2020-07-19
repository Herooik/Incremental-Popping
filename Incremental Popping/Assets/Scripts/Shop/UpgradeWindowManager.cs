using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeWindowManager : MonoBehaviour
{
    public static UpgradeWindowManager Instance { get; private set; }
    
    [SerializeField] private GameObject upgradePrefab;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private List<UpgradeData> upgrades;

    public List<Button> buyButtons;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetUpgradeElements();
        CheckIfButtonsCanBuy();
    }

    private void SetUpgradeElements()
    {
        for (int i = 0; i < upgrades.Count; i++)
        {
            var upgrade = Instantiate(upgradePrefab);
            upgrade.transform.SetParent(transform);

            var upgradeScript = upgrade.GetComponent<UpgradeElementController>();
            upgradeScript.SetUpElement(upgrades[i], descriptionText, buyButtons);
            upgradeScript.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void CheckIfButtonsCanBuy()
    {
        foreach (var button in buyButtons)
        {
            button.GetComponent<BuyButtonHandler>().CheckIfCanBuy();
        }
    }
}
