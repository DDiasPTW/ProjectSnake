using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public float deathTime;
    private bool autoDeath = true;
    [SerializeField] private float startAutoDeath;
    [SerializeField] private float autoDeathTime;
    [SerializeField]private bool canDie = false;
    public Material walkedOnMaterial;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        walkedOnMaterial = player.GetComponent<MeshRenderer>().material;
        startAutoDeath = autoDeathTime;
        autoDeath = true;
    }
    private void Update()
    {
        if (canDie)
        {
            deathTime -= Time.deltaTime;
            if (deathTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (Vector3.Distance(transform.position, player.transform.position) > 125f)
        {
            Destroy(gameObject);
        }

        if(autoDeath) startAutoDeath -= Time.deltaTime; if (startAutoDeath <= 0) Destroy(gameObject); //caso seja um bloco que o jogador nunca toque destroi-se para poupar recursos
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            canDie = true;
            autoDeath = false;
            gameObject.GetComponent<MeshRenderer>().material = walkedOnMaterial;
        }
    }

}
