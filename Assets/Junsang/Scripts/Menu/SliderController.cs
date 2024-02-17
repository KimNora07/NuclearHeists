using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public float FadedelayInSeconds = 0.0f;

    private void Start()
    {
        DisableSlider();
        StartCoroutine(EnableClickAfterDelay());
    }

    private void OnEnable()
    {
        DisableSlider();
        StartCoroutine(EnableClickAfterDelay());
    }

    public void DisableSlider()
    {
        slider.enabled = false;
    }

    public void EnableButton()
    {
        slider.enabled = true;
    }

    private IEnumerator EnableClickAfterDelay()
    {
        yield return new WaitForSeconds(FadedelayInSeconds);
        EnableButton();
    }
}
