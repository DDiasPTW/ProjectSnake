using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 2f;
    private bool isRight, isLeft, isForward, isBack;
    private float globalGravity = -9.81f;
    public float gravityScale = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        isForward = true; isBack = false; isLeft = false; isRight = false;
    }

    private void Update()
    {
        //Testing on PC
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Left();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Right();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Front();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Back();
        }
    }

    private void FixedUpdate()
    {
        //set gravity
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
        //set velocity
        if (isForward)
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if (isBack)
        {
            rb.velocity = -Vector3.forward * speed;
        }
        else if (isLeft)
        {
            rb.velocity = -Vector3.right * speed;
        }
        else if(isRight)
        {
            rb.velocity = Vector3.right * speed;
        }

    }

    public void Front()
    {
        isForward = true;isBack = false; isLeft = false; isRight = false;
    }

    public void Back()
    {
        isForward = false; isBack = true; isLeft = false; isRight = false;
    }

    public void Left()
    {
        isForward = false; isBack = false; isLeft = true; isRight = false;
    }

    public void Right()
    {
        isForward = false; isBack = false; isLeft = false; isRight = true;
    }
}
