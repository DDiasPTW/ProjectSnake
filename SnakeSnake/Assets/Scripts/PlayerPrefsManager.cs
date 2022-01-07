using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    [SerializeField] private bool Default = true;
    [SerializeField] private int HighScore = 0;
    [SerializeField] private int Coins = 0;
    [SerializeField] private int ColorPalette;
    [SerializeField] private bool color1, color2, color3, color4, color5, color6, color7, color8, color9, color10;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //PlayerPrefs.GetInt("Default", 0); //0 = Default, 1 = alternativo

        PlayerPrefs.GetInt("HS", 0); //HighScore

        PlayerPrefs.GetInt("Coins", 0); //Credits/coins/money whatever

        Colors();

        if (PlayerPrefs.GetInt("Color") == 0)
        {
            PlayerPrefs.SetInt("Color", 1); //default color palette
        }

        if (PlayerPrefs.GetInt("Unlocked1") == 0)
        {
            PlayerPrefs.SetInt("Unlocked1", 1);
        }
        
    }

    private void OnLevelWasLoaded(int level)
    {
        PlayerPrefs.Save();
    }

    private void Update()
    {
        //serve apenas para verificar o valor
        if (PlayerPrefs.GetInt("Default") == 0)
        {
            Default = true;
        }
        else Default = false;

        CheckUnlocked();

        ColorPalette = PlayerPrefs.GetInt("Color");

        Coins = PlayerPrefs.GetInt("Coins");

        HighScore = PlayerPrefs.GetInt("HS");


        if (PlayerPrefs.GetInt("Color") == 0)
        {
            PlayerPrefs.SetInt("Color", 1); //current color palette
        }

        //CLEAR ALL
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    PlayerPrefs.DeleteAll();
        //    PlayerPrefs.Save();
        //}
    }

    private void CheckUnlocked()
    {
        if (PlayerPrefs.GetInt("Unlocked1") == 1)
        {
            color1 = true;
        }
        if (PlayerPrefs.GetInt("Unlocked2") == 1)
        {
            color2 = true;
        }
        if (PlayerPrefs.GetInt("Unlocked3") == 1)
        {
            color3 = true;
        }
        if (PlayerPrefs.GetInt("Unlocked4") == 1)
        {
            color4 = true;
        }
        if (PlayerPrefs.GetInt("Unlocked5") == 1)
        {
            color5 = true;
        }
        if (PlayerPrefs.GetInt("Unlocked6") == 1)
        {
            color6 = true;
        }
        if (PlayerPrefs.GetInt("Unlocked7") == 1)
        {
            color7 = true;
        }
        if (PlayerPrefs.GetInt("Unlocked8") == 1)
        {
            color8 = true;
        }
        if (PlayerPrefs.GetInt("Unlocked9") == 1)
        {
            color9 = true;
        }
        if (PlayerPrefs.GetInt("Unlocked10") == 1)
        {
            color10 = true;
        }       
    }

    private void Colors()
    {
        PlayerPrefs.GetInt("Unlocked1",1); // 1 = yes, 0 = no
        PlayerPrefs.GetInt("Unlocked2", 0);
        PlayerPrefs.GetInt("Unlocked3", 0);
        PlayerPrefs.GetInt("Unlocked4", 0);
        PlayerPrefs.GetInt("Unlocked5", 0);
        PlayerPrefs.GetInt("Unlocked6", 0);
        PlayerPrefs.GetInt("Unlocked7", 0);
        PlayerPrefs.GetInt("Unlocked8", 0);
        PlayerPrefs.GetInt("Unlocked9", 0);
        PlayerPrefs.GetInt("Unlocked10", 0);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
