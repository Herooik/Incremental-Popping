using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCountController : MonoBehaviour
{
    [SerializeField] private IntReference popCount;
    [SerializeField] private FloatReference popTime;
    [SerializeField] private CircleCollider2D thisCollider;

    void Start()
    {
        popCount.Value++;

        StartCoroutine(DisablePop());
    }

    IEnumerator DisablePop()
    {
        yield return new WaitForSeconds(popTime.Value);

        thisCollider.enabled = false;
        
        popCount.Value--;
        if (popCount.Value == 0)
        {
            ScoreManager.Instance.AddRoundScoreToAllScore();
        }
    }
}
