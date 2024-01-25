using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadePanel : MonoBehaviour
{
    public Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();

        EventHandler.FadeInEvent += OnFadeIn;
        EventHandler.FadeOutEvent += OnFadeOut;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        EventHandler.FadeInEvent -= OnFadeIn;
        EventHandler.FadeOutEvent -= OnFadeOut;
    }

    private void OnFadeIn(float duration)
    {
        var targetColor = new Color(0,0,0,1);
        fadeImage.material.DOColor( targetColor, duration);
    }

    private void OnFadeOut(float duration)
    {
        var targetColor = new Color(0,0,0,0);
        fadeImage.material.DOColor( targetColor, duration);
    }
}
