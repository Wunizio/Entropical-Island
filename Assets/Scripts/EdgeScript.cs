using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class EdgeScript : MonoBehaviour
{

    public float initRadius;
    public SphereCollider sphereCol;
    public InGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        sphereCol = this.GetComponent<SphereCollider>();
        sphereCol.radius = initRadius/2;
    }

    // Update is called once per frame
    void Update()
    {
        sphereCol.radius += 80 * Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            gameManager.EndGame();
            
        }
    }
}
