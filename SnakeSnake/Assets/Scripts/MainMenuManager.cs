using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject otherSettingsMenu;

    private void Awake()
    {
        otherSettingsMenu.SetActive(false);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Main_Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Shop()
    {
        //abrir o menu da shop, blah blah
    }

    public void OtherSettings()
    {
        //abrir menu de other settings
        otherSettingsMenu.SetActive(true);
    }
}
