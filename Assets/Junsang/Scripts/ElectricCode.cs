using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricCode : MonoBehaviour
{
    public GameObject electricCodeObj;

    public Image redCode;
    public Image blueCode;
    public Image yellowCode;

    public Image halfRedCode1;
    public Image halfRedCode2;

    public Image halfBlueCode1;
    public Image halfBlueCode2;

    public Image halfYellowCode1;
    public Image halfYellowCode2;

    public Button redCodeBtn;
    public Button blueCodeBtn;
    public Button yellowCodeBtn;

    public bool isRed = false;
    public bool isBlue = false;
    public bool isYellow = false;

    private bool canRed = true;
    private bool canBlue = true;
    private bool canYellow = true;

    private void Start()
    {
        electricCodeObj.SetActive(false);
        redCode.gameObject.SetActive(true);
        blueCode.gameObject.SetActive(true);
        yellowCode.gameObject.SetActive(true);
        halfRedCode1.gameObject.SetActive(false);
        halfRedCode2.gameObject.SetActive(false);

        redCodeBtn.onClick.AddListener(CutRedCode);
        blueCodeBtn.onClick.AddListener(CutBlueCode);
        yellowCodeBtn.onClick.AddListener(CutYellowCode);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            electricCodeObj.SetActive(true);
        }
    }

    public void CutRedCode()
    {
        if (canRed)
        {
            redCode.gameObject.SetActive(false);
            halfRedCode1.gameObject.SetActive(true);
            halfRedCode2.gameObject.SetActive(true);
            isRed = true;
            canBlue = false;
            canYellow = false;
        }
    }

    public void CutBlueCode()
    {
        if (canBlue)
        {
            blueCode.gameObject.SetActive(false);
            halfBlueCode1.gameObject.SetActive(true);
            halfBlueCode2.gameObject.SetActive(true);
            isBlue = true;
            canRed = false;
            canYellow = false;
        }
    }

    public void CutYellowCode()
    {
        if (canYellow)
        {
            yellowCode.gameObject.SetActive(false);
            halfYellowCode1.gameObject.SetActive(true);
            halfYellowCode2.gameObject.SetActive(true);
            isYellow = true;
            canRed = false;
            canBlue = false;
        }
    }
}
