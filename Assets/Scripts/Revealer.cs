using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revealer : MonoBehaviour
{

    // Use this for initialization
    private GameObject[] hiddenObjects;

    void Awake()
    {
        hiddenObjects = GameObject.FindGameObjectsWithTag("HiddenObjectChildren");
        foreach (GameObject item in hiddenObjects)
        {
            item.SetActive(false);
        }
    }

    public void ShowChildren()
    {
        foreach (GameObject item in hiddenObjects)
        {
            item.SetActive(true);
        }
    }
}
