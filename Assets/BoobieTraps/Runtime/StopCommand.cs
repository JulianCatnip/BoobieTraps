using Naninovel;
using Naninovel.Commands;
using UnityEngine;

[CommandAlias("stopgamemusic")]
public class StopCommand : Command
{
    [ParameterAlias("reset")]
    public BooleanParameter ResetState = true;

    public override async UniTask ExecuteAsync (AsyncToken asyncToken = default)
    {
        // stop all background music
        AudioSource[] allAudioSources = Object.FindObjectsOfType<AudioSource>();
        foreach(AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }

        if (ResetState)
        {
            var stateManager = Engine.GetService<IStateManager>();
            await stateManager.ResetStateAsync();
        }
    }
}
