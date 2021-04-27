using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    public ShipController spaceShip;
    public GameObject[] objectiveObjects;
    public float objectiveTimerMin;
    public float objectiveTimerMax;
    public float objectiveSpace;
    public GameObject cassettes;
    public List<AudioClip> soundfiles;

    private float objectiveTimer;
    private int objectiveAmount;
    private float zDrop;

    // Start is called before the first frame update
    void Start()
    {
        objectiveTimer = Random.Range(objectiveTimerMin, objectiveTimerMax);
        objectiveAmount = 0;
        zDrop = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        objectiveTimer -= Time.deltaTime;
        if(objectiveTimer < 0)
        {
            if (objectiveAmount < 3)
            {
                spawnObjective(1);
                if(Random.Range(0, 100) > 50)
                {
                    spawnClip();
                }
                objectiveTimer = Random.Range(objectiveTimerMin, objectiveTimerMax);
                objectiveAmount++;
            }
            else
            {
                if (Random.Range(0, 100) > 35)
                {
                    spawnClip();
                }
                spawnObjective(Random.Range(2,4));
                objectiveTimer = Random.Range(objectiveTimerMin, objectiveTimerMax);
                objectiveAmount++;
            }
            
        }
        
        if (objectiveAmount == 6)
        {
            objectiveTimerMin /= 2;
            objectiveTimerMax /= 2;
            objectiveAmount++;
        }

        if (spaceShip.forwardSpeed > 125)
        {
            transform.localPosition = new Vector3(0, 0, 300);
        }
        else if (spaceShip.forwardSpeed > 200)
        {
            transform.localPosition = new Vector3(0, 0, 500);
        }
        else
        {
            transform.localPosition = new Vector3(0, 0, zDrop);
        }


    }

    private void spawnObjective(int spawnAmount)
    {
        for(int i = 0; i < spawnAmount; i++)
        {
            Vector3 randPosition = new Vector3(transform.position.x + Random.Range(-objectiveSpace, objectiveSpace), transform.position.y + Random.Range(-objectiveSpace, objectiveSpace), transform.position.z + Random.Range(-objectiveSpace, objectiveSpace));
            Instantiate(objectiveObjects[Random.Range(0, objectiveObjects.Length)], randPosition, Quaternion.identity);

        }
        
    }

    private void spawnClip()
    {
        if(soundfiles.Count != 0)
        {
            Vector3 randPosition = new Vector3(transform.position.x + Random.Range(-objectiveSpace, objectiveSpace), transform.position.y + Random.Range(-objectiveSpace, objectiveSpace), transform.position.z + Random.Range(-objectiveSpace, objectiveSpace));
            int fileN = Random.Range(0, soundfiles.Count);
            var newObject = Instantiate(cassettes, randPosition, Quaternion.Euler(90, 0, 0));
            newObject.GetComponent<PickupTape>().song = soundfiles[fileN];
            soundfiles.RemoveAt(fileN);
        }
        
    }


}
