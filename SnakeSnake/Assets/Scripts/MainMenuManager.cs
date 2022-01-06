using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject otherSettingsMenu;
    public GameObject ShopMenu;

    private void Awake()
    {
        otherSettingsMenu.SetActive(false);
        ShopMenu.SetActive(false);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("Main_Game");
    }

    public void Quit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void Shop()
    {
        //abrir o menu da shop, blah blah
        ShopMenu.SetActive(true);
    }

    public void OtherSettings()
    {
        //abrir menu de other settings
        otherSettingsMenu.SetActive(true);
    }
}
