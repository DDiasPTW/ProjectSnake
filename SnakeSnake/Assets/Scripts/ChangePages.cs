using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePages : MonoBehaviour
{
    public GameObject previousPage, thisPage, nextPage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Previous();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Next();
        }
    }

    public void Previous()
    {
        previousPage.SetActive(true);
        thisPage.SetActive(false);
    }

    public void Next()
    {
        nextPage.SetActive(true);
        thisPage.SetActive(false);
    }
}
