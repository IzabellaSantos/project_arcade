using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMovimentation : MonoBehaviour
{
    float z, x;

    // Update is called once per frame
    void Update()
    {
        z = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");

        if (z != 0 || x != 0)
            transform.Translate(x * Time.deltaTime, 0, z * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            //aumenta a velocidade por 5 segundos
        }
    }
}
