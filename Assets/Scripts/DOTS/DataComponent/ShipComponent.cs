using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct ShipComponent : IComponentData
{
    //Movement
    public float forwardSpeed;
    public float strafeSpeed;
    public float hoverSpeed;

    private float activeForwardSpeed;
    private float activeStrafeSpeed;
    private float activeHoverSpeed;

    private float forwardAcceleration;
    private float strafeAcceleration;
    private float hoverAcceleration;

    //Rotation
    public float lookRotateSpeed;

    private float2 lookInput;
    private float2 screenCenter;
    private float2 mouseDistance;

    //Keep rolling rolling what? Keep rolling rolling come on!
    public float rollSpeed;
    public float rollAcceleration;

    private float rollInput;
}
