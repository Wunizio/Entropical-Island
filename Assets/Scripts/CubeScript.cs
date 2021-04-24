using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 15);
    }


    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
