using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {

	public float scroolSpeed;
    public Renderer rend;


	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float y = Mathf.Repeat (Time.time * scroolSpeed, 1);
		Vector2 offset = new Vector2 (0,y);
        //renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        //rend.material.mainTextureOffset = new Vector2(offset, 0);
        rend.material.SetTextureOffset("_MainTex", -offset);
	}

    public void Fade()
    {
        for (float f = scroolSpeed; f >= 0; f -= 0.01f)
        {
            scroolSpeed = f;
        //    yield return null;
        }
    }
}
