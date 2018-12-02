using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revealer : MonoBehaviour {

	// Use this for initialization
	public List<GameObject> hiddenObject;
	void Start () {
		
	}
	
	public void ShowChildren(){
		foreach (GameObject item in hiddenObject)
		{
			item.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
