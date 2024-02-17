using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button[] button;
    [SerializeField] private TMP_Text[] text;

    Color col;

    private void OnEnable()
    {
        for(int i = 0; i < button.Length; i++)
        {
            col = text[i].color;
            col.a = 0;
            text[i].color = col;
            DisableButton();
            StartCoroutine(Fade(true));
        }
    }

    private void Start()
    {
        for (int i = 0; i < button.Length; i++)
        {
            col = text[i].color;
            col.a = 0;
            text[i].color = col;
            DisableButton();
            StartCoroutine(Fade(true));
        }
    }

    public void DisableButton()
    {

        for (int i = 0; i < button.Length; i++)
            if (button[i] != null)
            {
                button[i].enabled = false;
            }
    }

    public void EnableButton()
    {
        for (int i = 0; i < button.Length; i++)
            if (button[i] != null)
            {
                button[i].enabled = true;
            }
    }

    private IEnumerator Fade(bool isFadeIn)
    {
        yield return new WaitForSeconds(0.6f);
        if (isFadeIn)
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].alpha = 0;
                Tween tween = text[i].DOFade(1f, 0.3f);
                yield return tween.WaitForCompletion();
                EnableButton();
            }
        }
    }
}
