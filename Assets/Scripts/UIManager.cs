using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;		//Allows us to use Lists. 
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance = null;
	public Text levelText; //Text to display current level difficulty.
	public Text HPText; //Text to display current level difficulty.
	public Text countdownText; //Text to display current level difficulty.
    public GameObject levelImage;
    public GameObject inGameMenu;
    public Button pauseButton;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    //
    public void pause(){
        Time.timeScale = 0;
        pauseButton.gameObject.SetActive(false);
        inGameMenu.SetActive(true);
    }

    public void unpause(){
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        inGameMenu.SetActive(false);
    }
    public void quitGame(){
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        inGameMenu.SetActive(false);
        GameManager.instance.GameOver(false, 0);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
