using Unity.Entities;

[GenerateAuthoringComponent]
public struct GalaxyComponent : IComponentData
{

    public float angleChange;
    public float maxRadius;

    public float radius;
    public float theta;


    //Save surface of a sphere
    public float newX;
    public float newY;
    public float newZ;

    //Speed of cube
    public float speed;

}
