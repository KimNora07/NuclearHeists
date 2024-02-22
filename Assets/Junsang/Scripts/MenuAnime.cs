using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnime : MonoBehaviour
{
    DOTweenAnimation dgAnime;

    private void Awake()
    {
        dgAnime = GetComponent<DOTweenAnimation>();
    }

    private void Start()
    {
        dgAnime.DORestartById("0");
    }
}
