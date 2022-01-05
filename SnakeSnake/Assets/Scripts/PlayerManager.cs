using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject defaultCanvas, oppositeCanvas, loseCanvas;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            //Jogador perdeu, aparece loss menu
            loseCanvas.SetActive(true);
            Time.timeScale = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
