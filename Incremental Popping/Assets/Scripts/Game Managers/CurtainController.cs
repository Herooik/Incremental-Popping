using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurtainController : MonoBehaviour
{
    public static CurtainController Instance { get; private set; }
    [SerializeField] private Image curtainImage;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private SpawnStartBall spawnStartBall;
    [SerializeField] private Canvas gameplayCanvas;
    [SerializeField] private Canvas shopCanvas;
    [SerializeField] private TextMeshProUGUI descriptionText;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void MoveToTheGame()
    {
        StartCoroutine(ShowCurtainImage(shopCanvas, gameplayCanvas));

        spawnStartBall.enabled = true;
        
        SmallBallSpawnManager.Instance.SpawnSmallBalls();
    }

    public void MoveToTheShop()
    {
        StartCoroutine(ShowCurtainImage(gameplayCanvas, shopCanvas));

        SmallBallSpawnManager.Instance.DestroyRestBalls();

        descriptionText.text = "Touch upgrade name to see description and upgrade cost.";
    }
    
    private IEnumerator ShowCurtainImage(Canvas canvasToHide, Canvas canvasToShow)
    {
        curtainImage.gameObject.SetActive(true);
        var showCurtain = curtainImage.DOFillAmount(1, duration);
        yield return showCurtain.WaitForCompletion();

        canvasToHide.gameObject.SetActive(false);
        canvasToShow.gameObject.SetActive(true);
        
        curtainImage.fillOrigin = 0;
        
        var hideCurtain = curtainImage.DOFillAmount(0, duration);
        yield return hideCurtain.WaitForCompletion();
        curtainImage.gameObject.SetActive(false);

        curtainImage.fillOrigin = 1;
    }
}
