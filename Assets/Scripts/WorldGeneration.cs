using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{

    //public float middlePosition;
    public GameObject cube;
    //public float speed;
    public int amount;
    public float thiccness;

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        //speed = 0.01f;
        spawnWorld(amount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnWorld(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            
            //Height
            float spawnX = Random.Range(0, 180);
            //Radius around player
            float spawnY = Random.Range(0, 180);

            //Get a point on the surface of a sphere with radius enemyRadius
            //float newX = 0 + 500 * Mathf.Cos(spawnX * Mathf.Deg2Rad) * Mathf.Sin(spawnY * Mathf.Deg2Rad);
            //float newY = 0 + 500 * Mathf.Sin(spawnX * Mathf.Deg2Rad) * Mathf.Sin(spawnY * Mathf.Deg2Rad);
            //float newZ = 0 + 500 * Mathf.Cos(spawnY * Mathf.Deg2Rad);
            float newX = Random.Range(0, thiccness);
            float newY = Random.Range(0, thiccness);
            float newZ = Random.Range(0, thiccness);


            //newObject.GetComponent<CubeScript>().targetPosition = new Vector3(newX, newY, newZ);
            targetPosition = new Vector3(newX, newY, newZ);

            GameObject newObject = Instantiate(cube, targetPosition, Quaternion.identity);
            // this.GetComponent<Transform>().position = new Vector3(newX, newY, newZ);
        }


    }
}
