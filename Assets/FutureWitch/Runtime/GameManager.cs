using Naninovel;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance = null;
    enum GameState
    {
        NULL,
        START,
        PAUSE,
        END
    }
    private GameState gameState = GameState.NULL;
    private int previousLevel;
    private int currentLevel;
    public List<GameObject> levelList;

    public GameObject titleUI;
    public SpawnPoint playerSpawnPoint;
    public GameObject player;
    public SpawnPoint enemySpawnPoint;
    public Camera adventureModeCamera;

    void Awake()
    {
        if(sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
            // test
        }
    }

    public async void StartGame ()
    {
        //Debug.Log("StartGame called");
        gameState = GameState.START;
        previousLevel = currentLevel;
        currentLevel = 1;

        DisableLevel(previousLevel);
        LoadLevel(currentLevel);

        await RuntimeInitializer.InitializeAsync();
        
        //Debug.Log("Adventure command call");
        //var switchCommand = new AdventureTextMode { ResetState = false };
        //await switchCommand.ExecuteAsync();
        var switchCommand = new StartTextMode { ResetState = false, ScriptName = "Dialogue00", Label = "Start"};
        await switchCommand.ExecuteAsync();
        //ResetGameContent();
    }

    private void DisableLevel (int level)
    {
        levelList[level].SetActive(false);
        // reset level contents
    }

    private void LoadLevel (int level)
    {
        levelList[level].SetActive(true);
        // reset level contents
    }

    // Start is called before the first frame update
    private void Start ()
    {

        // 1. Initialize Naninovel.
        //await RuntimeInitializer.InitializeAsync();

        // 2. Comman "title" is executed
        //var switchCommand = new TitleMode { ResetState = false };
        //await switchCommand.ExecuteAsync();

        // 2. Enter Novel mode.
        // Debug.Log("Start");
        //var switchCommand = new NovelMode { ResetState = false };
        //await switchCommand.ExecuteAsync();

        // 2. Enter adventure mode.
        //Debug.Log("AdventureMode will be loaded now.");

        // 3. Initialize adventure camera and setup the scene
        //SetupScene();
    }

    public void SetupScene()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();
            //cameraManager.virtualCamera.Follow = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void ResetGameContent()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
