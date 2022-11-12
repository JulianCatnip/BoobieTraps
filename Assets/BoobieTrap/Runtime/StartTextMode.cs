using Naninovel;
using Naninovel.Commands;
using UnityEngine;

[CommandAlias("start")]
public class StartTextMode : Command
{
    [ParameterAlias("reset")]
    public BooleanParameter ResetState = true;
    public StringParameter name;
    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        Debug.Log("Starting call");
        var gameManager = Object.FindObjectOfType<GameManager>();
        gameManager.StartGame();

        if(Assigned(name))
        {
            var script = Engine.GetService<IScriptPlayer>();
            await script.PreloadAndPlayAsync(name);
        }
    }
}
