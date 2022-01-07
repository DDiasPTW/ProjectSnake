using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipsManager : MonoBehaviour
{
    [SerializeField] private int i = 1;
    private float timer;
    [SerializeField] private List<string> tips = new List<string>();
    public TMP_Text tip_Text;


    private void OnEnable()
    {
        timer = Random.Range(10,16);
        tip_Text.text = tips[0];
        i = Random.Range(1, tips.Count); //starts at 1 so that it doesn't display the same text twice off the bat
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            tip_Text.text = tips[i];
            i= Random.Range(0,tips.Count);
            timer = Random.Range(10,16);
        }

        if (i >= tips.Count) i =0; 
    }
}
