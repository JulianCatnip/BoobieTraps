using Naninovel;
using UnityEngine;

[CommandAlias("novel")]
public class NovelTextMode : Command
{
    [ParameterAlias("reset")]
    public BooleanParameter ResetState = true;
    public StringParameter ScriptName;
    public StringParameter Label;

    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default) // nur ausgeführt wenn reset true??
    {
        // 1. Disable character control.
        var controller = Object.FindObjectOfType<MovementController>();
        controller.enabled = false;

        // 4. Reset state (if required).
        if (ResetState)
        {
            var stateManager = Engine.GetService<IStateManager>();
            await stateManager.ResetStateAsync();
        }

        // 2. Switch cameras.
        var advCamera = GameObject.Find("AdventureModeCamera");
        advCamera.SetActive(false);
        var cmvcam1 = GameObject.Find("CMvcam1");
        cmvcam1.SetActive(false);
        
        var naniCamera = Engine.GetService<ICameraManager>().Camera;
        naniCamera.enabled = true;

        // 3. Load and play specified script (is required).
        if (Assigned(ScriptName))
        {
            var scriptPlayer = Engine.GetService<IScriptPlayer>();
            await scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label);
        }

        // 4. Enable Naninovel input.
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;
    }
}
