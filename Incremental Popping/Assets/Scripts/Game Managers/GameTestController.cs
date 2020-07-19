using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTestController : MonoBehaviour
{
    [SerializeField] private FloatReference ballAmount;
    [SerializeField] private FloatReference multiplier;
    [SerializeField] private FloatReference popSize;
    [SerializeField] private FloatReference popTime;

#if (UNITY_EDITOR)
    private void Awake()
    {
        ballAmount.Value = 20;
        multiplier.Value = 1.1f;
        popSize.Value = 9;
        popTime.Value = 1.7f;
    }
    #endif
}
