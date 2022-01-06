using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ReturnToMenu();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TryAgain();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Quit();
        }
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
