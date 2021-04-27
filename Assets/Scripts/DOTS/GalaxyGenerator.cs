using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Unity.Jobs;
using System.Collections.Generic;
using Unity.Collections;

public class GalaxyGenerator : MonoBehaviour
{

    public GameObject cube;
    public int amountLeft;
    public int amountDown;
    public float space;
    //public float speed;

    private Vector3 targetPosition;
    private BlobAssetStore blobby;
    private EntityManager entityManager;
    private Entity prefab;

    // Start is called before the first frame update
    void Start()
    {



        blobby = new BlobAssetStore();
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobby);
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(cube, settings);

        InstantiateEntityGrid(amountLeft, amountDown, space);
        //var instance = entityManager.Instantiate(prefab);

        //Destroy(cube);
    }

    private void InstantiateEntity(float3 position)
    {
        Entity myEntity = entityManager.Instantiate(prefab);
        entityManager.SetComponentData(myEntity, new Translation
        {
            Value = position
        });

    }

    private void InstantiateEntityGrid(int x, int y, float spacing)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                InstantiateEntity(new float3(i * spacing, j * spacing, 0f));
            }
        }
    }

    private void OnDestroy()
    {
        blobby.Dispose();
    }

}