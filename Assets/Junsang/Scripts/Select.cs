using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    public string player1;
    public string player2;

    public Button player1Btn;
    public Button player2Btn;

    private void Start()
    {
        player1Btn.onClick.AddListener(Select1p);
        player2Btn.onClick.AddListener(Select2p);
    }

    private void Select1p()
    {
        SceneManager.LoadScene(player1);
    }

    private void Select2p()
    {
        SceneManager.LoadScene(player2);
    }
}
