using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Break();
            return;
        }
        if (other.gameObject.tag == "Walls")
        {
            return;
        }
        if (other.gameObject.transform.parent != null)
        {
            other.gameObject.transform.parent.gameObject.SetActive(false);
            Destroy(other.gameObject.transform.parent.gameObject);
        }
        else
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
    }
}
