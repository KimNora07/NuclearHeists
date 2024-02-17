using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    [SerializeField] Button cancelButton;
    [SerializeField] Button enterButton;
    [SerializeField] private string code = "0192";
    private string Nr;

    private void Start()
    {
        cancelButton.onClick.AddListener(CancleFunc);
        enterButton.onClick.AddListener(EnterFunc);
    }

    public void CodeFunc(string _number)
    {
        AudioManager.Instance.PlaySFX("KeyPadClick");
        Nr = Nr + _number;
    }

    public void EnterFunc()
    {
        if(Nr == code)
        {
            AudioManager.Instance.PlaySFX("ConfirmClick");
            Debug.Log("일치합니다");
        }
        else
        {
            AudioManager.Instance.PlaySFX("ErrorClick");
            Debug.Log("불일치합니다");
        }
    }

    public void CancleFunc()
    {
        AudioManager.Instance.PlaySFX("KeyPadClick");
        Nr = null;
        Debug.Log($"초기화: {Nr}");
    }
}
