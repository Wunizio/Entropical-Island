using Unity.Entities;
using Unity.Jobs;
using Unity.Collections;
using Unity.Physics;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class GalaxySystem : SystemBase
{


    protected override void OnStartRunning()
    {

        Entities.ForEach((int entityInQueryIndex, ref GalaxyComponent galaxyData) =>
        {
            //galaxyData.radius = entityInQueryIndex;
            // galaxyData.radius = galaxyData.maxRadius * (Mathf.Sqrt(entityInQueryIndex / 400));
            galaxyData.radius = entityInQueryIndex;
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

        Entities.ForEach((int entityInQueryIndex, ref Translation trans, ref GalaxyComponent galaxyData) =>
        {
            
            var theta = galaxyData.angleChange * entityInQueryIndex;
            float newX = 300 + galaxyData.radius * Mathf.Cos(theta);
            float newY = 300 + galaxyData.radius * Mathf.Sin(theta);

            trans.Value = new float3(newX, newY, trans.Value.z);

            galaxyData.angleChange += deltaTime * 0.005f;
        }).ScheduleParallel();

    }
}
