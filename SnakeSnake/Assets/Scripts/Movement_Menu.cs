using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Menu : MonoBehaviour
{
    //(2,0,2) esquerda, (2,0,0) fren, (0,0,2) bai, (0,0,0) dir

    public float speed;
    private Rigidbody rb;
    [SerializeField] private int i = 0;
    public float minDistance;

    public GameObject[] wayPoints;

    public Material material;
    private ColorPaletteManager palette;
    private void Awake()
    {
        palette = GameObject.FindGameObjectWithTag("Floor").GetComponent<ColorPaletteManager>();
        rb = GetComponent<Rigidbody>();
        CheckColorPalette();
        gameObject.GetComponent<MeshRenderer>().material = material;
    }

    private void Update()
    {
        CheckColorPalette();
        gameObject.GetComponent<MeshRenderer>().material = material;

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[i].transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, wayPoints[i].transform.position) <= minDistance)
        {
            i++;
        }
        else return;

        if (i >= wayPoints.Length)
        {
            i = 0;
        } 
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

}
