using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls")
        {
            spawnWall(other.gameObject);
        }
    }

    // Update is called once per frame
    void spawnWall(GameObject walls)
    {
        walls.transform.position += (Vector3.down*200);
    }
}

