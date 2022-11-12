using Naninovel;
using Naninovel.UI;
using UnityEngine;

[CommandAlias("title")]
public class TitleMode : Command
{
    [ParameterAlias("reset")]
    public BooleanParameter ResetState = true;

    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
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

        // 3. Title UI
        var titleUI = Engine.GetService<IUIManager>().GetUI<ITitleUI>();
        titleUI?.Show();
        //var scriptPlayer = Engine.GetService<IScriptPlayer>();
        //await scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label);

        // 4. Enable Naninovel input.
        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;
    }
}
