using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGeneration : MonoBehaviour
{
    public float maxDistance;
    public float spawnDelay = 0.1f;
    private float delay;
    public GameObject cubePrefab;
    private GameObject player;
    [SerializeField] private bool hasPlaced = false;
    [SerializeField] private bool canSpawnFrente, canSpawnTras, canSpawnEsquerda, canSpawnDireita;
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    private void Start()
    {
        delay = spawnDelay;
    }
    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.forward * .4f, transform.TransformDirection(Vector3.forward), out hit, .5f))
        {
            canSpawnFrente = false;

            //if (hit.transform.GetComponent<CubeManager>().hasPlayer && !hasPlaced)
            //{
            //    PickSpawnDirection();
            //}
        }
        else canSpawnFrente = true;
        if (Physics.Raycast(transform.position + Vector3.back * .4f, transform.TransformDirection(Vector3.back), out hit, .5f))
        {
            if (hit.transform.position != transform.position)
            {
                canSpawnTras = false;
            }
        }
        else canSpawnTras = true;
        if (Physics.Raycast(transform.position + Vector3.right * .4f, transform.TransformDirection(Vector3.right), out hit, .5f))
        {
            if (hit.transform.position != transform.position)
            {
                canSpawnEsquerda = false;
            }
        }
        else canSpawnEsquerda = true;
        if (Physics.Raycast(transform.position + Vector3.left * .4f, transform.TransformDirection(Vector3.left), out hit, .5f))
        {
            if (hit.transform.position != transform.position)
            {
                canSpawnDireita = false;
            }
        }
        else canSpawnDireita = true;




        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            if (!hasPlaced && Vector3.Distance(transform.position, player.transform.position) <= maxDistance)
            {
                PickSpawnDirection();
            }
        } 
    }

    private void PickSpawnDirection()
    {
        if (!hasPlaced)
        {
            int direction = GetDirection();
            if (!canSpawnDireita) //DIREITA BLOQUEADA
            {
                if (direction == 0) //esquerda
                {
                    Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity);
                    hasPlaced = true;
                }
                else if (direction == 1) //frente
                {
                    Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); hasPlaced = true;
                }
                else { Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); hasPlaced = true; }
            }

            if (!canSpawnEsquerda) //ESQUERDA BLOQUEADA
            {
                if (direction == 0) //direita
                {
                    Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); hasPlaced = true;
                }
                else if (direction == 1) //frente
                {
                    Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); hasPlaced = true;
                }
                else { Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); hasPlaced = true; }
            }

            if (!canSpawnFrente) //FRENTE BLOQUEADA
            {
                if (direction == 0) //esquerda
                {
                    Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); hasPlaced = true;
                }
                else if (direction == 1) //direita
                {
                    Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); hasPlaced = true;
                }
                else { Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); hasPlaced = true; }
            }

            if (!canSpawnTras)
            {
                if (direction == 0) //esquerda
                {
                    Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); hasPlaced = true;
                }
                else if (direction == 1) //frente
                {
                    Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); hasPlaced = true;
                }
                else { Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); hasPlaced = true; }
            }
        }
        
    }

    
    private int GetDirection()
    {
        int i;
        i = Random.Range(0,3);
        return i;
    }
}
