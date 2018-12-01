using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MoneyDrop : MonoBehaviour {




    private Vector3 randomDirection;

    private Vector3 direction;

   // public Vector3 randomDirection { get; private set; }

    // Use this for initialization
    void Start () {
              //explosion billets direction random
              //vitesse de chute plus lente que celle du personnage
    	direction = Random.insideUnitCircle.normalized;

        Debug.Log("La direction du billet vert: "+direction);

        //randomDirection = new Vector3(Random.value, Random.value, Random.value);
        transform.Rotate(direction);
	}
	
	// Update is called once per frame
	void Update () {
       // transform.position += transform.forward  speed Time.deltaTime;
	}
}
