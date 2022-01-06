using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePages : MonoBehaviour
{
    public GameObject previousPage, thisPage, nextPage;

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
