using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager_Menu : MonoBehaviour
{
    public float deathTime;
    private float startDeathTime;
    public float reloadTime;
    [SerializeField] private bool canDie = false;

    public Material defaultMaterial;
    public Material walkedOnMaterial;
    private GameObject player;

    private ColorPaletteManager palette;

    private void Awake()
    {
        palette = GetComponent<ColorPaletteManager>();
        startDeathTime = deathTime;
    }

    private void OnEnable()
    {
        CheckColorPalette();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canDie = false;
    }
    private void Update()
    {

        //Debug.Log(PlayerPrefs.GetInt("Color"));
        if (canDie)
        {
            gameObject.GetComponent<MeshRenderer>().material = walkedOnMaterial;
            deathTime -= Time.deltaTime;
            if (deathTime <= 0)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                StartCoroutine(Reload());
                canDie = false;
            }
        }
        else gameObject.GetComponent<MeshRenderer>().material = defaultMaterial;

        CheckColorPalette();
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        deathTime = startDeathTime;
    }


    private void CheckColorPalette()
    {
        //Not viable in the long run but good enough for now
        if (PlayerPrefs.GetInt("Color") == 1)
        {
            defaultMaterial = palette.palette1[1];
            walkedOnMaterial = palette.palette1[2];
        }
        else if (PlayerPrefs.GetInt("Color") == 2)
        {
            Debug.Log("Color2");
            defaultMaterial = palette.palette2[1];
            walkedOnMaterial = palette.palette2[2];
        }
        else if (PlayerPrefs.GetInt("Color") == 3)
        {
            defaultMaterial = palette.palette3[1];
            walkedOnMaterial = palette.palette3[2];
        }
        else if (PlayerPrefs.GetInt("Color") == 4)
        {
            defaultMaterial = palette.palette4[1];
            walkedOnMaterial = palette.palette4[2];
        }
        else if (PlayerPrefs.GetInt("Color") == 5)
        {
            defaultMaterial = palette.palette5[1];
            walkedOnMaterial = palette.palette5[2];
        }
        else if (PlayerPrefs.GetInt("Color") == 6)
        {
            defaultMaterial = palette.palette6[1];
            walkedOnMaterial = palette.palette6[2];
        }
        else if (PlayerPrefs.GetInt("Color") == 7)
        {
            defaultMaterial = palette.palette7[1];
            walkedOnMaterial = palette.palette7[2];
        }
        else if (PlayerPrefs.GetInt("Color") == 8)
        {
            defaultMaterial = palette.palette8[1];
            walkedOnMaterial = palette.palette8[2];
        }
        else if (PlayerPrefs.GetInt("Color") == 9)
        {
            defaultMaterial = palette.palette9[1];
            walkedOnMaterial = palette.palette9[2];
        }
        else if (PlayerPrefs.GetInt("Color") == 10)
        {
            defaultMaterial = palette.palette10[1];
            walkedOnMaterial = palette.palette10[2];
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            canDie = true;
        }
        else canDie = false;
    }
}
