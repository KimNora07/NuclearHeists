using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("NewLevel")]
    [SerializeField] private string _newGame;

    [Header("Buttons")]
    [SerializeField] private Button menu_StartButton;
    [SerializeField] private Button menu_OptionButton;
    [SerializeField] private Button menu_ExitButton;
    [SerializeField] private Button option_GraphicButton;
    [SerializeField] private Button option_SoundButton;
    [SerializeField] private Button option_BackButton;
    [SerializeField] private Button start_YesButton;
    [SerializeField] private Button start_NoButton;
    [SerializeField] private Button Exit_YesButton;
    [SerializeField] private Button Exit_NoButton;
    [SerializeField] private Button Graphic_FullScreenButton;
    [SerializeField] private Button Graphic_DefaultButton;
    [SerializeField] private Button Graphic_BackButton;
    [SerializeField] private Button Graphic_ApplyButton;
    [SerializeField] private Button Sound_DefaultButton;
    [SerializeField] private Button Sound_BackButton;
    [SerializeField] private Button Sound_ApplyButton;

    [Header("Panels")]
    [SerializeField] private GameObject menu_Panel;
    [SerializeField] private GameObject option_Panel;
    [SerializeField] private GameObject exit_Panel;
    [SerializeField] private GameObject start_Panel;
    [SerializeField] private GameObject sound_Panel;
    [SerializeField] private GameObject graphic_Panel;


    [Header("SelectObject")]
    [SerializeField] private GameObject[] _menuList;
    [SerializeField] private Button[] _firstSelectButton;
    [SerializeField] private Slider[] _firstSelectSlider;
    [SerializeField] private int _Menuindex = 0;
    [SerializeField] private int _Buttonindex = 0;
    [SerializeField] private int _Sliderindex = -1;

    private void Start()
    {
        menu_StartButton.onClick.AddListener(Menu_StartButton);
        menu_OptionButton.onClick.AddListener(Menu_OptionButton);
        menu_ExitButton.onClick.AddListener(Menu_ExitButton);
        option_GraphicButton.onClick.AddListener(Option_GraphicButton);
        option_SoundButton.onClick.AddListener(Option_SoundButton);
        option_BackButton.onClick.AddListener(BackToMenuButton);
        start_YesButton.onClick.AddListener(StartButton);
        start_NoButton.onClick.AddListener(BackToMenuButton);
        Exit_YesButton.onClick.AddListener(ExitButton);
        Exit_NoButton.onClick.AddListener(BackToMenuButton);
        Graphic_FullScreenButton.onClick.AddListener(FullScreenButton);
        Graphic_DefaultButton.onClick.AddListener(DefaultButton);
        Graphic_BackButton.onClick.AddListener(BackToOptionButton);
        Graphic_ApplyButton.onClick.AddListener(ApplyButton);
        Sound_DefaultButton.onClick.AddListener(DefaultButton);
        Sound_BackButton.onClick.AddListener(BackToOptionButton);
        Sound_ApplyButton.onClick.AddListener(ApplyButton);

        SelectedMenu(_Menuindex, _Buttonindex, _Sliderindex);
    }

    public void SelectedMenu(int MenuIndex, int ButtonIndex, int SliderIndex)
    {
        foreach (GameObject menu in _menuList)
        {
            menu.SetActive(false);
        }
        _menuList[MenuIndex].SetActive(true);
        if (_Buttonindex >= 0)
            _firstSelectButton[ButtonIndex].Select();
        if (_Sliderindex >= 0)
        {
            _firstSelectSlider[SliderIndex].Select();
        }
    }

    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(.3f);
        SelectedMenu(_Menuindex, _Buttonindex, _Sliderindex);
    }

    public void Menu_StartButton()
    {
        
    }

    public void Menu_OptionButton()
    {
        
    }

    public void Menu_ExitButton()
    {

    }

    public void StartButton()
    {
        SceneManager.LoadScene(_newGame);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void Option_GraphicButton()
    {
        
    }

    public void Option_SoundButton()
    {
        
    }

    public void FullScreenButton()
    {

    }

    public void BackToMenuButton()
    {

    }

    public void BackToOptionButton()
    {

    }

    public void DefaultButton()
    {

    }

    public void ApplyButton()
    {

    }
}
