using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct CubeComponent : IComponentData
{
    public float radius;

    //Save surface of a sphere
    public float newX;
    public float newY;
    public float newZ;
    //Get surface of a sphere
    public float spawnX;
    public float spawnY;
    //Speed of cube
    public float speed;

    //Get min and max init speed
    public float min;
    public float max;
    //Define furthest distance cube can go
    public float speedDistance;

}
