using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{

    public GameObject[] objectiveObjects;
    public float objectiveTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        objectiveTimer -= Time.deltaTime;
        if(objectiveTimer < 0)
        {
            spawnObjective();
            objectiveTimer = Random.Range(3, 10);
        }    
    }

    private void spawnObjective()
    {
        Vector3 randPosition = new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5), transform.position.z + Random.Range(-5, 5) );
        Instantiate(objectiveObjects[Random.Range(0, objectiveObjects.Length)], randPosition, Quaternion.identity);
    }


}
