﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour 
{
    public float scrollSpeed;
	public float tileSizeY;
    private Vector3 startPosition;

	 

    public void Start ()
	{
		startPosition = transform.position;

	}

	void Update ()
	{
		
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);
		transform.position = (startPosition + Vector3.down * newPosition);
	}
}
