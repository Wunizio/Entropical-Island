using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

/*public struct CubeJob : IJobParallelFor
{
    public void Execute(int index)
    {

    }
}

public class CubeManager : MonoBehaviour
{

}*/

public class ChonkGeneration : MonoBehaviour
{

    //public float middlePosition;
    public GameObject cube;
    public int amount;
    public float cubeThiccness;
    //public float speed;

    private Vector3 targetPosition;
    private BlobAssetStore blobby;
    private Unity.Mathematics.Random rand;

    // Start is called before the first frame update
    void Start()
    {
        blobby = new BlobAssetStore();
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobby);
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(cube, settings);
        var entitiyManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        rand = new Unity.Mathematics.Random(1);
        for (int x = 0; x < amount; x++)
        {
            //
            var instance = entitiyManager.Instantiate(prefab);



            float newX = rand.NextFloat(0, cubeThiccness);
            float newY = rand.NextFloat(0, cubeThiccness);
            float newZ = rand.NextFloat(0, cubeThiccness);

            var position = transform.TransformPoint(new float3(newX, newY, newZ));
            entitiyManager.SetComponentData(instance, new Translation { Value = position });
        }

        //Destroy(cube);
    }

    private void OnDestroy()
    {
        blobby.Dispose();
    }

}
