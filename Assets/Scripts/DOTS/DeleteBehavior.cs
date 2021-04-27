using Unity.Jobs;
using Unity.Entities;
using Unity.Collections;

public class DeleteBehavior : JobComponentSystem
{
    public bool a;

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {

        if (a)
        {
            EntityCommandBuffer commandBuffer = new EntityCommandBuffer(Allocator.TempJob);

            Entities.WithAll<DeleteTag>().ForEach((Entity entity) =>
            {
                commandBuffer.DestroyEntity(entity);
            }).Run();

            commandBuffer.Playback(EntityManager);
            commandBuffer.Dispose();

            return default;
        }
        else
        {
            return default;
        }

        
    }

}