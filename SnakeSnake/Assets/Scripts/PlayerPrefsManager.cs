using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    [SerializeField] private bool Default = true;
    [SerializeField] private int HighScore = 0;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        PlayerPrefs.GetInt("Default", 0); //0 = Default, 1 = alternativo
        PlayerPrefs.GetInt("HS", 0);
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

        HighScore = PlayerPrefs.GetInt("HS");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
