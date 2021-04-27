using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpawnComponent : IComponentData
{

    
    public float newX;
    public float newY;
    public float newZ;
    public float spawnX;
    public float spawnY;
    public float speed;

    //Get max and min initial speed
    public float maxSpeed;
    public float minSpeed;

}
