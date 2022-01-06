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

    public Material material;
    private ColorPaletteManager palette;

    public int Score = 0;
    private int Coins = 0;

    private void Awake()
    {
        Time.timeScale = 1;
        Score = 0;
        Coins = PlayerPrefs.GetInt("Coins");
        palette = GameObject.FindGameObjectWithTag("Floor").GetComponent<ColorPaletteManager>();
        loseCanvas.SetActive(false);

        
        //se !opposite
        if (PlayerPrefs.GetInt("Default") == 0)  //0 = Default, 1 = alternativo
        {
            defaultCanvas.SetActive(true); oppositeCanvas.SetActive(false);
        }else if (PlayerPrefs.GetInt("Default") == 1)
        {
            //se opposite
            defaultCanvas.SetActive(false); oppositeCanvas.SetActive(true);
        }
        
        CheckColorPalette();
        gameObject.GetComponent<MeshRenderer>().material = material;
    }


    private void Update()
    {
        if (transform.position.y <= 0) //perdeu
        {
            loseCanvas.SetActive(true);
            Time.timeScale = 0;
            PlayerPrefs.SetInt("Coins", Coins); 

            if (PlayerPrefs.GetInt("HS") < Score)
            {
                PlayerPrefs.SetInt("HS", Score);
                PlayerPrefs.Save();
            }
        }

        //highScore
        timeAlive += Time.deltaTime;
        scoreText.text = Score.ToString();
    }

    private void CheckColorPalette()
    {
        //Not viable in the long run but good enough for now
        if (PlayerPrefs.GetInt("Color") == 1)
        {
            material = palette.palette1[0];
        }
        else if (PlayerPrefs.GetInt("Color") == 2)
        {
            material = palette.palette2[0];

        }
        else if (PlayerPrefs.GetInt("Color") == 3)
        {
            material = palette.palette3[0];
        }
        else if (PlayerPrefs.GetInt("Color") == 4)
        {
            material = palette.palette4[0];

        }
        else if (PlayerPrefs.GetInt("Color") == 5)
        {
            material = palette.palette5[0];
        }
        else if (PlayerPrefs.GetInt("Color") == 6)
        {
            material = palette.palette6[0];
        }
        else if (PlayerPrefs.GetInt("Color") == 7)
        {
            material = palette.palette7[0];
        }
        else if (PlayerPrefs.GetInt("Color") == 8)
        {
            material = palette.palette8[0];
        }
        else if (PlayerPrefs.GetInt("Color") == 9)
        {
            material = palette.palette9[0];
        }
        else if (PlayerPrefs.GetInt("Color") == 10)
        {
            material = palette.palette10[0];
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Floor"))
        {
            Score++;
            Coins++;
        }
    }
}
