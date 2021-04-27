using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Unity.Jobs;
using System.Collections.Generic;
using Unity.Collections;

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
    public GameObject[] cube;
    public int amount;
    public float cubeThiccness;
    GameObjectConversionSettings settings;
    EntityManager entitiyManager;
    Unity.Mathematics.Random rand;
    Entity[] prefab;
    //public float speed;

    private Vector3 targetPosition;
    private BlobAssetStore blobby;

    // Start is called before the first frame update
    void Start()
    {
        uint randomRange = (uint)UnityEngine.Random.Range(1, 10000000);
        rand = new Unity.Mathematics.Random(randomRange);

        blobby = new BlobAssetStore();
        settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobby);
        entitiyManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        prefab = new Entity[cube.Length];


       for(int x = 0; x < cube.Length; x++)
        {
            prefab[x] = GameObjectConversionUtility.ConvertGameObjectHierarchy(cube[x], settings);
        }

        for (int x = 0; x < amount; x++)
        {
           
            var instance = entitiyManager.Instantiate(prefab[rand.NextInt(0, cube.Length)]);
            

        }

        //Destroy(cube);
    }

    private void OnDestroy()
    {
        blobby.Dispose();
    }

}