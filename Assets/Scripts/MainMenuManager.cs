using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startGame()
    {
        SceneManager.LoadScene("mainscene", LoadSceneMode.Single);
        GameManager.instance.enabled = true;
    }

    public void setDifficulty(int difficultyLevel)
    {
		PlayerPrefs.SetInt("difficultyLevel", difficultyLevel);
    }
}
