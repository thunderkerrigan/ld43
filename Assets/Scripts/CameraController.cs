using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Orientation
{
    Left,
    Right
}

public class CameraController : MonoBehaviour
{

    private float stopScroll = 5;
    public GameObject player;
    private bool groundTest = false;

    public Paralax otherParallax;

    private Vector3 offset;
    private Vector3 initialPosition;

    private float distanceLeft = 8.5f;
    private float distanceRight = 8.5f;

    private float velocity = 2;

    public GameObject[] leftWalls;
    public GameObject[] rightWalls;

    public GameObject background;


    private void Awake()
    {
        offset = transform.position - player.transform.position;
        initialPosition = transform.position;
    }

    void Update()
    {

        if (groundTest == true)
        {
            StartCoroutine("Fade");
            groundTest = false;
        }

        Vector3 newPos = initialPosition;
        newPos.y = player.transform.position.y - stopScroll;
        newPos.x = player.transform.position.x;

        if (newPos.x < -4)
        {
            newPos.x = -4;
        }
        else if (newPos.x > 4)
        {
            newPos.x = 4;
        }

        float newDistanceLeft = player.transform.position.x - leftWalls[0].transform.position.x;
        float leftRotationVector = ((distanceLeft - newDistanceLeft) * velocity);
        distanceLeft = newDistanceLeft;

        float newdistanceRight = rightWalls[0].transform.position.x - player.transform.position.x;
        float rightRotationVector = ((distanceRight - newdistanceRight) * velocity);
        distanceRight = newdistanceRight;

        foreach (GameObject leftWall in leftWalls)
        {
            leftWall.transform.Rotate(Vector3.up, leftRotationVector);
            adjustWallRotation(leftWall, Orientation.Left);
        }
        foreach (GameObject rightWall in rightWalls)
        {
            rightWall.transform.Rotate(Vector3.down, rightRotationVector);
            adjustWallRotation(rightWall, Orientation.Right);
        }

        if (newPos.x < -4)
        {
            newPos.x = -4;
        }
        else if (newPos.x > 4)
        {
            newPos.x = 4;
        }

        var followCam = new Vector3(newPos.x, newPos.y, -10);
        transform.position = followCam;
    }

    //TODO
    void adjustWallRotation(GameObject wall, Orientation orientation)
    {
        if (orientation == Orientation.Left && wall.transform.rotation.y <= -10)
        {
            wall.transform.rotation = Quaternion.Euler(0, -10, 0);
        }

        if (orientation == Orientation.Right && wall.transform.rotation.y >= 10)
        {
            wall.transform.rotation = Quaternion.Euler(0, 10, 0);
        }
    }
    public void groundControl()
    {
        // la camera arrete de scroll, le sol est bloqué en bas de la caméra.
        //stopScroll = -5;
        groundTest = true;

    }
    IEnumerator Fade()
    {
        otherParallax.Fade();

        for (float f = 5; f >= -5; f -= 0.05f)
        {
            stopScroll = f;
            yield return null;
        }
        // GameManager.instance.spawnGround();
    }
}
