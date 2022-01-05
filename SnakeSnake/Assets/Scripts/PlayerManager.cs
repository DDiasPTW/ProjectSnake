using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject defaultCanvas, oppositeCanvas, loseCanvas;

    public TMP_Text scoreText;
    private float timeAlive;

    private void Awake()
    {
        Time.timeScale = 1;
        loseCanvas.SetActive(false);
        //adicionar um if statement para saber se jogador prefere um ou outro canvas
        //se !opposite
        if (PlayerPrefs.GetInt("Default") == 0)  //0 = Default, 1 = alternativo
        {
            defaultCanvas.SetActive(true); oppositeCanvas.SetActive(false);
        }else if (PlayerPrefs.GetInt("Default") == 1)
        {
            //se opposite
            defaultCanvas.SetActive(false); oppositeCanvas.SetActive(true);
        }
    }

    private void Update()
    {
        if (transform.position.y <= 0) //perdeu
        {
            loseCanvas.SetActive(true);
            Time.timeScale = 0;

            if (PlayerPrefs.GetInt("HS") < (int)timeAlive)
            {
                PlayerPrefs.SetInt("HS", (int)timeAlive);
                PlayerPrefs.Save();
            }
        }

        //highScore
        timeAlive += Time.deltaTime;
        scoreText.text = timeAlive.ToString("F0");
    }
}
