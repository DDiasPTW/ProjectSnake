using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseMenuManager : MonoBehaviour
{

    public TMP_Text highScore_Text, currentScoreText;
    private GameObject player;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentScoreText.text = player.GetComponent<PlayerManager>().Score.ToString();
        highScore_Text.text = PlayerPrefs.GetInt("HS").ToString();
    }
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
        Time.timeScale = 1;
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
