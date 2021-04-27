using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeScript : MonoBehaviour
{

    public float initRadius;
    public SphereCollider sphereCol;
    // Start is called before the first frame update
    void Start()
    {
        sphereCol = this.GetComponent<SphereCollider>();
        sphereCol.radius = initRadius/2;
    }

    // Update is called once per frame
    void Update()
    {
        sphereCol.radius += 35 * Time.deltaTime;
    }
}
