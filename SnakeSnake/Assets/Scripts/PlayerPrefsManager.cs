using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    [SerializeField] private bool Default = true;
    private void Awake()
    {
        PlayerPrefs.GetInt("Default", 0); //0 = Default, 1 = alternativo
    }

    private void Update()
    {
        //serve apenas para verificar o valor
        if (PlayerPrefs.GetInt("Default") == 0)
        {
            Default = true;
        }
        else Default = false;
    }
}
