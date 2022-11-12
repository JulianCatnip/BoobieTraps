using Naninovel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance = null;
    public SpawnPoint playerSpawnPoint;
    public SpawnPoint enemySpawnPoint;
    public CameraManager cameraManager;
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
        }
    }

    // Start is called before the first frame update
    private async void Start ()
    {
        // 1. Initialize Naninovel.
        await RuntimeInitializer.InitializeAsync();

        // 2. Enter menu mode.
        var switchCommand = new NovelMode { ResetState = false };
        await switchCommand.ExecuteAsync();

        // 2. Enter adventure mode.
        //var switchCommand = new AdventureMode { ResetState = false };
        //await switchCommand.ExecuteAsync();

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
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
