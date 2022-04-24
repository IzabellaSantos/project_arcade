using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMovimentation : MonoBehaviour
{
    float z, x;
    public float velocityPowerUp;

    void Start()
    {
        velocityPowerUp = 10;
    }
    // Update is called once per frame
    void Update()
    {
        z = Input.GetAxis("Vertical") * velocityPowerUp;
        x = Input.GetAxis("Horizontal") * velocityPowerUp;

        if (z != 0 || x != 0)
            transform.Translate(x * Time.deltaTime, 0, z * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            velocityPowerUp += 5; //adicionar o tempo
        }
    }
}
