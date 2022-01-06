using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject ShopMenu;

    private void Awake()
    {
        ShopMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayButton();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Shop();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Quit();
        }
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
}
