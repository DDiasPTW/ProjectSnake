using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherSettingsMenuManager : MonoBehaviour
{
    public GameObject defaultBorder, otherBorder;
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("Default") == 0)
        {
            defaultBorder.SetActive(true); otherBorder.SetActive(false);
        }else if(PlayerPrefs.GetInt("Default") == 1)
        {
            defaultBorder.SetActive(false); otherBorder.SetActive(true);
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("Default") == 0)
        {
            defaultBorder.SetActive(true); otherBorder.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Default") == 1)
        {
            defaultBorder.SetActive(false); otherBorder.SetActive(true);
        }
    }
    public void SetDefault()
    {
        PlayerPrefs.SetInt("Default", 0);
    }
    public void SetOther()
    {
        PlayerPrefs.SetInt("Default", 1);
    }

    public void Back()
    {
        gameObject.SetActive(false);
    }
}
