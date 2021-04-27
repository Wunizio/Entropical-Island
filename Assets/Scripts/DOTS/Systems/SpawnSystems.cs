using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Physics;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class SpawnSystems : SystemBase
{

    //private ;
    //private 
    //private 

    protected override void OnStartRunning()
    {
        // rand = new Unity.Mathematics.Random(1);

        Entities.ForEach((ref CubeComponent cubeData) =>
        {
            uint randomRange = (uint)UnityEngine.Random.Range(1, 10000000);
            Unity.Mathematics.Random rand = new Unity.Mathematics.Random(randomRange);
            float spawnX = rand.NextFloat(0, 180);
            float spawnY = rand.NextFloat(0, 360);
            cubeData.radius = rand.NextFloat(cubeData.min, cubeData.max);
            cubeData.newX = 0.5f * Mathf.Cos(spawnX * Mathf.Deg2Rad) * Mathf.Sin(spawnY * Mathf.Deg2Rad);
            cubeData.newY = 0.5f * Mathf.Sin(spawnX * Mathf.Deg2Rad) * Mathf.Sin(spawnY * Mathf.Deg2Rad);
            cubeData.newZ = 0.5f * Mathf.Cos(spawnY * Mathf.Deg2Rad);
            //TODO put this in update to make it work

            //transform.Value = new Quaternion(rand.NextFloat(0, 180), rand.NextFloat(0, 180), rand.NextFloat(0, 180), rand.NextFloat(0, 180));

        }).Run();
    }

    protected override void OnCreate()
    {
        base.OnCreate();
    }

    protected override void OnUpdate() 
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation trans, ref CubeComponent cubeData) =>
        {
            if (cubeData.radius > cubeData.speedDistance)
            {
                cubeData.speed -= 10 * deltaTime;
            }
               
            cubeData.radius += cubeData.speed * deltaTime;

            float newX = cubeData.newX * cubeData.radius;
            float newY = cubeData.newY * cubeData.radius;
            float newZ = cubeData.newZ * cubeData.radius;

            trans.Value = new float3(newX, newY, newZ);
        }).ScheduleParallel();

    }
}
