using UnityEngine;
using Naninovel;

public class Dialogue : MonoBehaviour
{
    public string ScriptName;
    public string Label;

    private void OnTriggerEnter (Collider other)
    {
        // Stop movement of character
        //var controller = other.gameObject.GetComponentInChildren<CharacterController3D>();
        //controller.IsInputBlocked = true;

        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;

        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label).Forget();
    }
}
