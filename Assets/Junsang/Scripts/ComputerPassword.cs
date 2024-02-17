using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComputerPassword : MonoBehaviour
{
    [SerializeField] private TMP_InputField password;
    [SerializeField] private TMP_Text passwordText;
    [SerializeField] private string _password = "Hello";

    private void Update()
    {
        EnterPassword();
    }

    public void EnterPassword()
    {
        if (password.text != null)
        {
            if (passwordText.text != null)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (password.text == _password)
                    {
                        Debug.Log("일치합니다");
                    }
                    else
                    {
                        Debug.Log("불일치합니다");
                    }
                }
            }
        }
    }
}
