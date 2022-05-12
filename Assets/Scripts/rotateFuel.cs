using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateFuel : MonoBehaviour
{

    Transform fuel;
    // Start is called before the first frame update
    void Start()
    {
        fuel = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        fuel.Rotate(Vector3.up, 1);
    }
}
