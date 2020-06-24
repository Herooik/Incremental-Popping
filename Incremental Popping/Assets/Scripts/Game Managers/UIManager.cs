using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private Image curtainImage;
    [SerializeField] private Canvas gameplayCanvas;
    [SerializeField] private Canvas shopCanvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void MoveToTheGame()
    {
        StartCoroutine(ShowCurtainImage(shopCanvas, gameplayCanvas));
        
        GameController.Instance.SetGame(true);
    }

    public void MoveToTheShop()
    {
        StartCoroutine(ShowCurtainImage(gameplayCanvas, shopCanvas));

        GameController.Instance.SetGame(false);
    }

    IEnumerator ShowCurtainImage(Canvas canvasToHide, Canvas canvasToShow)
    {
        curtainImage.gameObject.SetActive(true);
        var showCurtain = curtainImage.DOFillAmount(1, 0.5f);
        yield return showCurtain.WaitForCompletion();

        canvasToHide.gameObject.SetActive(false);
        canvasToShow.gameObject.SetActive(true);
        
        curtainImage.fillOrigin = 0;
        
        var hideCurtain = curtainImage.DOFillAmount(0, 0.5f);
        yield return hideCurtain.WaitForCompletion();
        curtainImage.gameObject.SetActive(false);

        curtainImage.fillOrigin = 1;
    }
}
