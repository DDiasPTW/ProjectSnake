using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenuManager : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ReturnToMenu();
        }

        if (Input.GetKeyDown(KeyCode.R))
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
