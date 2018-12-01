using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableSpawner : MonoBehaviour
{


    public GameObject[] enemy;

    public GameObject[] money;


    public GameObject ground;
    private Vector3 spawnerOrigin;
    public float sec = 5f;
    private int maxObject = 4;

    private bool canSpawn = true;

    public CameraController other;

    private Difficulty currentDifficulty;


    float randomX = 0;
    private GameObject[] instanciatedFloors;


    private void Awake()
    {
        spawnerOrigin = transform.position;
    }

    public void startSpawn(){
        currentDifficulty = GameManager.instance.difficulty;
        spawnEnemy();
        StartCoroutine(LateCall(currentDifficulty.levelTimeout));
    }

    void Update()
    {
        float newX = (Mathf.Repeat(Time.time * 10, 14) - 7);
        Vector3 currentPos = transform.position;
        currentPos.x = newX;
        transform.position = currentPos;
    }

    // Update is called once per frame
    void spawnEnemy()
    {
        if (canSpawn == true)
        {
            int index = Random.Range(0, currentDifficulty.enemyDifficulty);
            GameObject wall = enemy[index];
            Vector3 newPosition = transform.position;
            //newPosition.x = spawnerOrigin.x;
            Instantiate(wall, newPosition, Quaternion.identity);// spwan de l'objet
            Invoke("spawnEnemy", Random.Range(currentDifficulty.spawnRate, currentDifficulty.spawnRate+2));// relance la fonction spawnWall
        }
        else
        {
            Debug.Log("cant spawn");
        }
    }
    IEnumerator LateCall(int timeout)
    {
        yield return new WaitForSeconds(timeout);
        print("Activation Spawner");
        GameManager.instance.spawnGround();
        Invoke("spawnGround", 5.0f);
    }

    // Fonction pour call depuis un autre scipt, voir GameManager
    public void spawnGround()
    {
        canSpawn = false;
        CancelInvoke("spawnEnemy");
        Vector3 newPosition = transform.position;
        Instantiate(ground, newPosition, Quaternion.identity);// spawn de l'objet 
    }
    public void spawnMoney()
    {
        if (canSpawn == true)
        {
            GameObject booty = money[Random.Range(0, money.Length - 1)];
            Debug.Log(booty);
            Vector3 newPosition = transform.position;
            Instantiate(booty, newPosition, Quaternion.identity);// spawn de l'objet
            Invoke("spawnMoney", Random.Range(1, 2));// relance la fonction spawnMoney
        }else{
            Debug.Log("cant spawn");
        }
    }

}

