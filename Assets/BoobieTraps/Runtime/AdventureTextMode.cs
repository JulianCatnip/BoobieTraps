using Naninovel;
using Naninovel.Commands;
using UnityEngine;

[CommandAlias("adventure")]
public class AdventureTextMode : Command
{
    [ParameterAlias("reset")]
    public BooleanParameter ResetState = true;
    [ParameterAlias("start")]
    public BooleanParameter StartingCall;
    public StringParameter ScriptName;
    //public StringParameter Label;

    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        Debug.Log("Adventure command called");
        // 1. Disable Naninovel input.
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = false;

        // 2. Stop script player.
        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.Stop();

        // 3. Hide text printer.
        var hidePrinter = new HidePrinter();
        hidePrinter.ExecuteAsync(asyncToken).Forget();

        // 4. Reset state (if required).
        if (ResetState)
        {
            var stateManager = Engine.GetService<IStateManager>();
            await stateManager.ResetStateAsync();
        }

        /*if (StartingCall)
        {
            Debug.Log("Starting call");
            var gameManager = Object.FindObjectOfType<GameManager>();
            gameManager.StartGame();
            
            //var script = Engine.GetService<IScriptPlayer>();
            //await script.PreloadAndPlayAsync(ScriptName);
        }*/

        // 5. Disable naninovel cameras.
        Debug.Log("Disable NaniCamera");
        var naniCamera = Engine.GetService<ICameraManager>().Camera;
        naniCamera.enabled = false;

        var advCamera = GameObject.Find("AdventureModeCamera");
        advCamera.SetActive(true);
        var cmvcam1 = GameObject.Find("CMvcam1");
        cmvcam1.SetActive(true);

        // 6. Enable character control.
        var playerControl = Object.FindObjectOfType<MovementController>();
        playerControl.enabled = true;
        var playerRb = playerControl.GetComponent<Rigidbody2D>();
        playerRb.bodyType = RigidbodyType2D.Dynamic;
    }
}
