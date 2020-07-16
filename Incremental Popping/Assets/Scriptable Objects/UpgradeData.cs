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
    [SerializeField] private List<double> upgradeCost;

    
    public string GetName()
    {
        return upgradeName;
    }
    
    public string GetDescription()
    {
        return description;
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

    public float GetValueToAdd()
    {
        var value = (maxValue - valueToUpgrade.Value) / upgradeCost.Count;
        return value;
    }
}
