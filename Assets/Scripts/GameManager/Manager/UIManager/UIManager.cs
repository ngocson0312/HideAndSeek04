using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public RectTransform DefaultUI, NoAdsUI;

    private void Start()
    {
        DefaultUI.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void AdsButton()
    {
        DefaultUI.DOAnchorPos(new Vector2(800, -800), 0.25f);
        NoAdsUI.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void CloseAdsButton()
    {
        NoAdsUI.DOAnchorPos(new Vector2(800, -800), 0.25f);
        DefaultUI.DOAnchorPos(new Vector2(0, 0), 0.25f);
        
    }
}
