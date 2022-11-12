using UnityEngine;
using Cinemachine;

public class RoundCameraPos : CinemachineExtension
{
    public float pixelsPerUnit = 32;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(stage == CinemachineCore.Stage.Body)
        {
            Vector3 pos1 = state.FinalPosition;
            Vector3 pos2 = new Vector3(Round(pos1.x), Round(pos1.y), pos1.z);

            state.PositionCorrection += pos2 - pos1;
        }
    }

    float Round(float x)
    {
        return Mathf.Round(x * pixelsPerUnit) / pixelsPerUnit;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
