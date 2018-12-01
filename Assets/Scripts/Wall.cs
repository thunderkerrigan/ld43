using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        transform.position += Vector3.up * Time.timeScale * player.velocity;
    }
}

