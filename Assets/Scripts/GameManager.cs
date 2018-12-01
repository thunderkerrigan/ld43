using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;		//Allows us to use Lists. 
using UnityEngine.UI;                   //Allows us to use UI.


public class GameManager : MonoBehaviour
{
    public float levelStartDelay = 2f;                      //Time to wait before starting level, in seconds.
    public int playerHitPoints = 100;                      //Starting value for Player food points.
    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.							//Image to block out level as levels are being set up, background for levelText.
    private Player player;
    private int level = 1;                                  //Current level number, expressed in game as "Day 1".
    private List<Enemy> enemies;                            //List of all Enemy units, used to issue them move commands.
    private bool doingSetup = true;                         //Boolean to check if we're setting up board, prevent Player from moving during setup.
    public Difficulty difficulty = new Normal();

    private float timeout;

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


        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        //Assign enemies to a new List of Enemy objects.
        enemies = new List<Enemy>();

        //Call the InitGame function to initialize the first level 
        // InitGame();
    }

    void getDifficultyLevel()
    {
        int difficultyLevel = PlayerPrefs.GetInt("difficultyLevel");
        switch (difficultyLevel)
        {
            case 0:
                difficulty = new Easy();
                break;
            case 1:
                difficulty = new Normal();
                break;
            case 2:
                difficulty = new Hard();
                break;
            default:
                difficulty = new Normal();
                PlayerPrefs.SetInt("difficultyLevel", 1);
                break;
        }
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        level++;
        Scene __scene = SceneManager.GetActiveScene();
        Debug.Log("loaded scene: " + __scene.name);
        if (__scene.name == "mainscene")
        {
            Debug.Log("OUI C'EST BIEN LA MAIN SCENE!");
            InitGame();
        }
    }
    void OnEnable()
    {
        Debug.Log("ENABLE!");
        SceneManager.sceneLoaded += instance.OnLevelFinishedLoading;
    }
    void OnDisable()
    {
        Debug.Log("DISABLE!");
        SceneManager.sceneLoaded -= instance.OnLevelFinishedLoading;
    }

    public void showMenu()
    {
        GameManager.instance.enabled = false;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //While doingSetup is true the player can't move, prevent player from moving while title card is up.
        doingSetup = true;
        getDifficultyLevel();
        timeout = difficulty.levelTimeout;

        //Get a reference to our image LevelImage by finding it by name.
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        player.enabled = true;

        // player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        player.stopPlayer();

        SoundManager.instance.musicSource.Stop();
        //Get a reference to our image LevelImage by finding it by name.

        //Set the text of levelText to the string "Day" and append the current level number.
        UIManager.instance.levelText.text = difficulty.name;

        //Set levelImage to active blocking player's view of the game board during setup.
        UIManager.instance.levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);

        //Clear any Enemy objects in our List to prepare for next level.
        enemies.Clear();

        //Call the SetupScene function of the BoardManager script, pass it current level number.
        //TODO
        // boardScript.SetupScene(level);

    }


    //Hides black image used between levels
    void HideLevelImage()
    {
        //Disable the levelImage gameObject.
        UIManager.instance.levelImage.SetActive(false);
        MovableSpawner spawner = GameObject.Find("Spawner").GetComponent<MovableSpawner>();
        spawner.startSpawn();
        SoundManager.instance.musicSource.Play();
        // player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        player.startPlayer();
        //Set doingSetup to false allowing player to move again.
        doingSetup = false;
    }

    //Update is called every frame.
    void Update()
    {
        //Check that playersTurn or enemiesMoving or doingSetup are not currently true.
        if (doingSetup)
        {
            //If any of these are true, return and do not start MoveEnemies.
            return;
        }
        timeout -= Time.deltaTime;
        if (timeout < 0)
        {
            UIManager.instance.countdownText.text = "";
        }
        else
        {
            UIManager.instance.countdownText.text = timeout + "s";
        }
    }

    //Call this to add the passed in Enemy to the List of Enemy objects.
    public void AddEnemyToList(Enemy script)
    {
        //Add Enemy to List enemies.
        enemies.Add(script);
    }

    public void spawnGround()
    {
        CameraController controller = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        controller.groundControl();
    }

    //GameOver is called when the player reaches 0 food points
    public void GameOver(bool isWin, float delay = 3.0f)
    {
        player.GetComponent<Rigidbody2D>().mass = 0;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        MovableSpawner spawner = GameObject.Find("Spawner").GetComponent<MovableSpawner>();
        spawner.gameObject.SetActive(false);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Debug.Log("destroying: " + enemy);
            Destroy(enemy);
        }
        //Set levelText to display number of levels passed and game over message
        if (isWin)
        {
            UIManager.instance.levelText.text = " GG! tu as gagné plein des pepettes!";
        }
        else
        {
            UIManager.instance.levelText.text = level + " GAME OVER";
        }

        //Enable black background image gameObject.
        UIManager.instance.levelImage.SetActive(true);

        //Disable this GameManager.
        // enabled = false;
        Invoke("showMenu", delay);
    }
}
