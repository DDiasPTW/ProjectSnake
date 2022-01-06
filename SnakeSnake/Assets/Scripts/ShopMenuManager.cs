using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenuManager : MonoBehaviour
{
    public TMP_Text coins;
    public int Price = 2500;
    public GameObject border1, border2, border3, border4, border5, border6, border7, border8, border9, border10;
    public GameObject price2, price3, price4, price5, price6, price7, price8, price9, price10;
    

    private void OnEnable()
    {
        CheckColor();
    }

    private void Update()
    {
        coins.text = "Coins: " + PlayerPrefs.GetInt("Coins").ToString();

        CheckColor();

        CheckUnlocked();
    }

    private void CheckColor()
    {
        if (PlayerPrefs.GetInt("Color") == 1)
        {
            border1.SetActive(true);
        }
        else border1.SetActive(false);

        if (PlayerPrefs.GetInt("Color") == 2)
        {
            border2.SetActive(true);
        }
        else border2.SetActive(false);

        if (PlayerPrefs.GetInt("Color") == 3)
        {
            border3.SetActive(true);
        }
        else border3.SetActive(false);

        if (PlayerPrefs.GetInt("Color") == 4)
        {
            border4.SetActive(true);
        }
        else border4.SetActive(false);

        if (PlayerPrefs.GetInt("Color") == 5)
        {
            border5.SetActive(true);
        }
        else border5.SetActive(false);

        if (PlayerPrefs.GetInt("Color") == 6)
        {
            border6.SetActive(true);
        }
        else border6.SetActive(false);

        if (PlayerPrefs.GetInt("Color") == 7)
        {
            border7.SetActive(true);
        }
        else border7.SetActive(false);

        if (PlayerPrefs.GetInt("Color") == 8)
        {
            border8.SetActive(true);
        }
        else border8.SetActive(false);

        if (PlayerPrefs.GetInt("Color") == 9)
        {
            border9.SetActive(true);
        }
        else border9.SetActive(false);

        if (PlayerPrefs.GetInt("Color") == 10)
        {
            border10.SetActive(true);
        }
        else border10.SetActive(false);
    }

    private void CheckUnlocked()
    {
        if (PlayerPrefs.GetInt("Unlocked2") == 1)
        {
            price2.SetActive(false);
        }else price2.SetActive(true);
        if (PlayerPrefs.GetInt("Unlocked3") == 1)
        {
            price3.SetActive(false);
        }
        else price3.SetActive(true);
        if (PlayerPrefs.GetInt("Unlocked4") == 1)
        {
            price4.SetActive(false);
        }
        else price4.SetActive(true);
        if (PlayerPrefs.GetInt("Unlocked5") == 1)
        {
            price5.SetActive(false);
        }
        else price5.SetActive(true);
        if (PlayerPrefs.GetInt("Unlocked6") == 1)
        {
            price6.SetActive(false);
        }
        else price6.SetActive(true);
        if (PlayerPrefs.GetInt("Unlocked7") == 1)
        {
            price7.SetActive(false);
        }
        else price7.SetActive(true);
        if (PlayerPrefs.GetInt("Unlocked8") == 1)
        {
            price8.SetActive(false);
        }
        else price8.SetActive(true);
        if (PlayerPrefs.GetInt("Unlocked9") == 1)
        {
            price9.SetActive(false);
        }
        else price9.SetActive(true);
        if (PlayerPrefs.GetInt("Unlocked10") == 1)
        {
            price10.SetActive(false);
        }
        else price10.SetActive(true);
    }

    public void Back()
    {
        gameObject.SetActive(false);
    }
    public void Color1()
    {
        PlayerPrefs.SetInt("Color",1);
    }
    public void Color2()
    {
        if (PlayerPrefs.GetInt("Unlocked2") == 1)
        {
            PlayerPrefs.SetInt("Color", 2);
        }
        else if (PlayerPrefs.GetInt("Coins") >= Price && PlayerPrefs.GetInt("Unlocked2") == 0)
        {
            int coins = PlayerPrefs.GetInt("Coins");
            int newCoins = coins - Price;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("Color", 2);
            PlayerPrefs.SetInt("Unlocked2",1);
        }
        else return;
    }
    public void Color3()
    {
        if (PlayerPrefs.GetInt("Unlocked3") == 1)
        {
            PlayerPrefs.SetInt("Color", 3);
        }
        else if (PlayerPrefs.GetInt("Coins") >= Price && PlayerPrefs.GetInt("Unlocked3") == 0)
        {
            int coins = PlayerPrefs.GetInt("Coins");
            int newCoins = coins - Price;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("Color", 3);
            PlayerPrefs.SetInt("Unlocked3", 1);
        }
        else return;
    }
    public void Color4()
    {
        if (PlayerPrefs.GetInt("Unlocked4") == 1)
        {
            PlayerPrefs.SetInt("Color", 4);
        }
        else if (PlayerPrefs.GetInt("Coins") >= Price && PlayerPrefs.GetInt("Unlocked4") == 0)
        {
            int coins = PlayerPrefs.GetInt("Coins");
            int newCoins = coins - Price;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("Color", 4);
            PlayerPrefs.SetInt("Unlocked4", 1);
        }
        else return;
    }
    public void Color5()
    {
        if (PlayerPrefs.GetInt("Unlocked5") == 1)
        {
            PlayerPrefs.SetInt("Color", 5);
        }
        else if (PlayerPrefs.GetInt("Coins") >= Price && PlayerPrefs.GetInt("Unlocked5") == 0)
        {
            int coins = PlayerPrefs.GetInt("Coins");
            int newCoins = coins - Price;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("Color", 5);
            PlayerPrefs.SetInt("Unlocked5", 1);
        }
        else return;
    }
    public void Color6()
    {
        if (PlayerPrefs.GetInt("Unlocked6") == 1)
        {
            PlayerPrefs.SetInt("Color", 6);
        }
        else if (PlayerPrefs.GetInt("Coins") >= Price && PlayerPrefs.GetInt("Unlocked6") == 0)
        {
            int coins = PlayerPrefs.GetInt("Coins");
            int newCoins = coins - Price;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("Color", 6);
            PlayerPrefs.SetInt("Unlocked6", 1);
        }
        else return;
    }
    public void Color7()
    {
        if (PlayerPrefs.GetInt("Unlocked7") == 1)
        {
            PlayerPrefs.SetInt("Color", 7);
        }
        else if (PlayerPrefs.GetInt("Coins") >= Price && PlayerPrefs.GetInt("Unlocked7") == 0)
        {
            int coins = PlayerPrefs.GetInt("Coins");
            int newCoins = coins - Price;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("Color", 7);
            PlayerPrefs.SetInt("Unlocked7", 1);
        }
        else return;
    }
    public void Color8()
    {
        if (PlayerPrefs.GetInt("Unlocked8") == 1)
        {
            PlayerPrefs.SetInt("Color", 8);
        }
        else if (PlayerPrefs.GetInt("Coins") >= Price && PlayerPrefs.GetInt("Unlocked8") == 0)
        {
            int coins = PlayerPrefs.GetInt("Coins");
            int newCoins = coins - Price;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("Color", 8);
            PlayerPrefs.SetInt("Unlocked8", 1);
        }
        else return;
    }
    public void Color9()
    {
        if (PlayerPrefs.GetInt("Unlocked9") == 1)
        {
            PlayerPrefs.SetInt("Color", 9);
        }
        else if (PlayerPrefs.GetInt("Coins") >= Price && PlayerPrefs.GetInt("Unlocked9") == 0)
        {
            int coins = PlayerPrefs.GetInt("Coins");
            int newCoins = coins - Price;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("Color", 9);
            PlayerPrefs.SetInt("Unlocked9", 1);
        }
        else return;
    }
    public void Color10()
    {
        if (PlayerPrefs.GetInt("Unlocked10") == 1)
        {
            PlayerPrefs.SetInt("Color", 10);
        }
        else if (PlayerPrefs.GetInt("Coins") >= Price && PlayerPrefs.GetInt("Unlocked10") == 0)
        {
            int coins = PlayerPrefs.GetInt("Coins");
            int newCoins = coins - Price;
            PlayerPrefs.SetInt("Coins", newCoins);
            PlayerPrefs.SetInt("Color", 10);
            PlayerPrefs.SetInt("Unlocked10", 1);
        }
        else return;
    }
}
