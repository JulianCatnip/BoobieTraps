using Naninovel;
using Naninovel.Commands;
using UnityEngine;

[CommandAlias("start")]
public class StartTextMode : Command
{
    [ParameterAlias("reset")]
    public BooleanParameter ResetState = true;
    public string ScriptName;
    public string Label;

    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        Debug.Log("Start command called");

        // 5. Disable naninovel cameras.
        Debug.Log("Disable NaniCamera");
        var naniCamera = Engine.GetService<ICameraManager>().Camera;
        naniCamera.enabled = false;

        var advCamera = GameObject.Find("AdventureModeCamera");
        advCamera.SetActive(true);
        var cmvcam1 = GameObject.Find("CMvcam1");
        cmvcam1.SetActive(true);

        // 1. Disable character control.
        var playerControl = Object.FindObjectOfType<MovementController>();
        playerControl.enabled = false;
        var playerRb = playerControl.GetComponent<Rigidbody2D>();
        playerRb.bodyType = RigidbodyType2D.Kinematic;

        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;

        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label).Forget();

        // 3. Hide text printer.
        //var hidePrinter = new HidePrinter();
        //hidePrinter.ExecuteAsync(asyncToken).Forget();

        // 4. Reset state (if required).
        if (ResetState)
        {
            var stateManager = Engine.GetService<IStateManager>();
            await stateManager.ResetStateAsync();
        }

    }
}
