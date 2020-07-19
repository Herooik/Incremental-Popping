using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    [SerializeField] private string upgradeName;
    [SerializeField] private string description;
    [SerializeField] private FloatVariable valueToUpgrade;
    [SerializeField] private float startValue;
    [SerializeField] private float maxValue;
    [SerializeField] private int indexUpgradeCost;
    [SerializeField] private List<double> upgradeCost;

    private float _valueToAdd;

    
    public string GetName()
    {
        return upgradeName;
    }
    
    public string GetDescription()
    {
        if (IsMaxUpgrade())
        {
            return description + "\n" + upgradeName + " is maxed out!";
        }
        return description + "\nNext upgrade cost: " + upgradeCost[indexUpgradeCost];
    }

    public float GetVariable()
    {
        return valueToUpgrade.Value;
    }
    
    public float GetStartValue()
    {
        return startValue;
    }
    
    public float GetMaxValue()
    {
        return maxValue;
    }

    public double GetUpgradeCost()
    {
        if (IsMaxUpgrade())
        {
            return double.NaN;
        }

        return upgradeCost[indexUpgradeCost];
    }

    public bool IsMaxUpgrade()
    {
        if (indexUpgradeCost == upgradeCost.Count)
        {
            return true;
        }

        return false;
    }

    public void UpgradeValue()
    {
        valueToUpgrade.Value += _valueToAdd;
        indexUpgradeCost++;
    }

    public float GetValueToAdd()
    {
        _valueToAdd = (maxValue - valueToUpgrade.Value) / upgradeCost.Count;
        return _valueToAdd;
    }
}
