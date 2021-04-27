using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterScript : MonoBehaviour
{

    public enum item
    {
        boost,
        turnAround
    }

    public item effect;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            switch (effect)
            {
                case item.boost:
                    other.GetComponent<ShipController>().boost();
                    Destroy(gameObject);
                    return;
                case item.turnAround:
                    other.GetComponent<ShipController>().spin();
                    Destroy(gameObject);
                    return;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
