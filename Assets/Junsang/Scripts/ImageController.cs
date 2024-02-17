using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image Img;
    Color col;
    public float FadedelayInSeconds = 0.0f;

    void Start()
    {
        col = Img.color;
        col.a = 0;
        Img.color = col;
        StartCoroutine(Fade(true));
    }

    private void OnEnable()
    {
        col = Img.color;
        col.a = 0;
        Img.color = col;
        StartCoroutine(Fade(true));
    }

    private IEnumerator Fade(bool isFadeIn)
    {
        yield return new WaitForSeconds(FadedelayInSeconds);
        if (isFadeIn)
        {
            col = Img.color;
            col.a = 0;
            Img.color = col;
            Tween tween = Img.DOFade(1f, 0.3f);
            yield return tween.WaitForCompletion();
        }
    }
}
