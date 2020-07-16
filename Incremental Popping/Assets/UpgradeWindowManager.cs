using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeWindowManager : MonoBehaviour
{
    [SerializeField] private GameObject upgradePrefab;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private List<UpgradeData> upgrades;

    private void Start()
    {
        for (int i = 0; i < upgrades.Count; i++)
        {
            var upgrade = Instantiate(upgradePrefab);
            upgrade.transform.SetParent(transform);

            upgrade.GetComponent<UpgradeElementController>().SetUpElement(upgrades[i], descriptionText);
        }
    }
    
    
}
