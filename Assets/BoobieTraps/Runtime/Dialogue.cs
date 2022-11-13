using UnityEngine;
using Naninovel;

public class Dialogue : MonoBehaviour
{
    public string ScriptName;
    public string Label;

    private void OnTriggerEnter2D (Collider2D other)
    {
        // Stop movement of character
        var controller = Object.FindObjectOfType<MovementController>();
        controller.enabled = false;

        var inputManager = Engine.GetService<IInputManager>();
        inputManager.ProcessInput = true;

        var scriptPlayer = Engine.GetService<IScriptPlayer>();
        scriptPlayer.PreloadAndPlayAsync(ScriptName, label: Label).Forget();
    }
}
