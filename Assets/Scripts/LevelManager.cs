using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject[] walls;
    private float speed = 2f;
    private Vector3 eastStartingPoint;
    private Vector3 westStartingPoint;
    private GameObject[] eastWalls;
    private GameObject[] westWalls;

    void Start()
    {
        Rect rect = Camera.main.rect;
        westStartingPoint = new Vector3(rect.x, rect.yMax);
        eastStartingPoint = new Vector3(rect.xMax - 1, rect.yMax);
        Vector3 westPosition = rect.position;
        Vector3 eastPosition = new Vector3(rect.xMax, rect.y);

        while (westPosition.y < westStartingPoint.y)
        {
            GameObject wall = walls[Random.Range(0, walls.Length - 1)];
            addWalls(wall, westWalls, westPosition);
            westPosition = westPosition + Vector3.down;
        }
        while (eastPosition.y < eastStartingPoint.y)
        {
            GameObject wall = walls[Random.Range(0, walls.Length - 1)];
            addWalls(wall, westWalls, eastPosition);
            eastPosition = eastPosition + Vector3.down;
        }

    }
    void Update()
    {
        moveWalls(eastWalls);
        moveWalls(westWalls);
    }

    private void addWalls(GameObject wall, GameObject[] wallsCollection, Vector3 position)
    {
        Instantiate(wall, position, Quaternion.identity);
        wallsCollection[wallsCollection.Length] = wall;
        
    }

    private void moveWalls(GameObject[] wallsCollection)
    {
        foreach (GameObject wall in wallsCollection)
        {
            if (wall.GetComponent<Renderer>().isVisible)
            {
                wall.transform.position = (wall.transform.position + Vector3.down * speed);
            }
            else
            {
                wall.gameObject.SetActive(false);
                GameObject newWall = walls[Random.Range(0, walls.Length - 1)];
                Instantiate(newWall, eastStartingPoint, Quaternion.identity);
                wallsCollection[wallsCollection.Length] = newWall;
            }
        }
    }
}

