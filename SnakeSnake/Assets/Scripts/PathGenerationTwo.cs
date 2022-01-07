using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerationTwo : MonoBehaviour
{
    public float spawnDelay = 0.45f;
    private float delay;


    [SerializeField] private bool Right, Left, Front, Back, CanPlace;
    private GameObject player;
    [SerializeField] private float minDistance;
    public GameObject cubePrefab;

    private GameObject difficultyManager;

    private void Start()
    {
        CanPlace = true;
        delay = spawnDelay;
        difficultyManager = GameObject.FindGameObjectWithTag("DM");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        spawnDelay = difficultyManager.GetComponent<DifficultyManager>().spawnSpeed;

        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= minDistance && CanPlace)
            {
                GeneratePath();
            }
        }
    }

    private void FixedUpdate()
    {
        DetectEmptySides();
    }

    void DetectEmptySides()
    {
        RaycastHit hit;

        //FRENTE
        if (Physics.Raycast(transform.position + Vector3.forward * .4f, transform.TransformDirection(Vector3.forward), out hit, .5f))
        {
            Debug.DrawRay(transform.position + Vector3.forward * .4f, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Front = false;
        }
        else
        {
            Debug.DrawRay(transform.position + Vector3.forward * .4f, transform.TransformDirection(Vector3.forward) * .5f, Color.green);
            Front = true;
        }

        //TRAS
        if (Physics.Raycast(transform.position + Vector3.back * .4f, transform.TransformDirection(Vector3.back), out hit, .5f))
        {
            Debug.DrawRay(transform.position + Vector3.back * .4f, transform.TransformDirection(Vector3.back) * hit.distance, Color.red);
            Back = false;
        }
        else
        {
            Debug.DrawRay(transform.position + Vector3.back * .4f, transform.TransformDirection(Vector3.back) * .5f, Color.green);
            Back = true;
        }

        //DIREITA
        if (Physics.Raycast(transform.position + Vector3.right * .4f, transform.TransformDirection(Vector3.right), out hit, .5f))
        {
            Debug.DrawRay(transform.position + Vector3.right * .4f, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
            Right = false;
        }
        else
        {
            Debug.DrawRay(transform.position + Vector3.right * .4f, transform.TransformDirection(Vector3.right) * .5f, Color.green);
            Right = true;
        }

        //ESQUERDA
        if (Physics.Raycast(transform.position + Vector3.left * .4f, transform.TransformDirection(Vector3.left), out hit, .5f))
        {
            Debug.DrawRay(transform.position + Vector3.left * .4f, transform.TransformDirection(Vector3.left) * hit.distance, Color.red);
            Left = false;
        }
        else
        {
            Debug.DrawRay(transform.position + Vector3.left * .4f, transform.TransformDirection(Vector3.left) * .5f, Color.green);
            Left = true;
        }
    }

    void GeneratePath() //Need to find more efficient way to do this
    {
        if (Right && Front && Left && Back)
        {
            int i = Calc4();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); CanPlace = false;
            }
            else if (i == 2)
            {
                Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); CanPlace = false;
            }else if (i == 3)
            {
                Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); CanPlace = false;
            }
        }

        else if (Right && Front && Left && !Back)
        {
            int i = Calc3();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); CanPlace = false;
            }else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); CanPlace = false;
            }else if (i == 2)
            {
                Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); CanPlace = false;
            }
        }
        else if (Front && Left && Back && !Right)
        {
            int i = Calc3();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); CanPlace = false;
            }
            else if (i == 2)
            {
                Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); CanPlace = false;
            }
        }
        else if (Left && Back && Right && !Front)
        {
            int i = Calc3();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); CanPlace = false;
            }
            else if (i == 2)
            {
                Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); CanPlace = false;
            }
        }
        else if (Front && Back && Right && !Left)
        {
            int i = Calc3();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); CanPlace = false;
            }
            else if (i == 2)
            {
                Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); CanPlace = false;
            }
        }
        
        else if (Left && Right && !Back && !Front)
        {
            int i = Calc2();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); CanPlace = false;
            }
        }
        else if (Back && Right && !Front && !Left)
        {
            int i = Calc2();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); CanPlace = false;
            }
        }
        else if (Front && Right && !Back && !Left)
        {
            int i = Calc2();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); CanPlace = false;
            }
        }
        else if (Front && Left && !Right && !Back)
        {
            int i = Calc2();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); CanPlace = false;
            }
        }
        else if (Front && Back && !Left && !Right)
        {
            int i = Calc2();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); CanPlace = false;
            }
        }
        else if (Left && Back && !Right && !Front)
        {
            int i = Calc2();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); CanPlace = false;
            }
        }
        
        else if (Front && !Back && !Left && !Right)
        {
            Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); CanPlace = false;
        }
        else if (!Front && Back && !Left && !Right)
        {
            Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); CanPlace = false;
        }
        else if (!Front && !Back && Left && !Right)
        {
            Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); CanPlace = false;
        }
        else if (!Front && !Back && !Left && Right)
        {
            Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); CanPlace = false;
        }

        else
        {
            int i = Calc4();
            if (i == 0)
            {
                Instantiate(cubePrefab, transform.position + Vector3.forward, Quaternion.identity); CanPlace = false;
            }
            else if (i == 1)
            {
                Instantiate(cubePrefab, transform.position + Vector3.right, Quaternion.identity); CanPlace = false;
            }
            else if (i == 2)
            {
                Instantiate(cubePrefab, transform.position + Vector3.left, Quaternion.identity); CanPlace = false;
            }
            else if (i == 3)
            {
                Instantiate(cubePrefab, transform.position + Vector3.back, Quaternion.identity); CanPlace = false;
            }
        }
    }

    int Calc4()
    {
        int i = Random.Range(0, 4);

        return i;
    }
    int Calc3()
    {
        int i = Random.Range(0,3);

        return i;
    }

    int Calc2()
    {
        int i = Random.Range(0, 2);

        return i;
    }


}
