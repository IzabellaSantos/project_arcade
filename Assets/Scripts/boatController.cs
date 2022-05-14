using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class boatController : MonoBehaviour
{
    public Vector3 COM;
    [Space(15)]
    private float steerSpeed = 10f, movementThresold = 5f;

    Transform m_COM;
    float verticalInput, movementFactor, horizontalInput, steerFactor;
    GameObject player;
    playerStatus boat;

    private void Start()
    {
        player = GameObject.FindWithTag("Player"); //acha o player
        boat = player.GetComponent<playerStatus>();
    }
    void FixedUpdate()
    {
        Balance();
        Movement();
        Steer();
    }

    void Balance()
    {
        if (!m_COM)
        {
            m_COM = new GameObject("COM").transform;
            m_COM.SetParent(transform);
        }

        m_COM.position = COM;
        GetComponent<Rigidbody>().centerOfMass = m_COM.position;
    }

    void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        movementFactor = Mathf.Lerp(movementFactor, verticalInput, Time.deltaTime / movementThresold);
        transform.Translate(0.0f, 0.0f, movementFactor * boat.speed);
    }

    void Steer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        steerFactor = Mathf.Lerp(steerFactor, horizontalInput * verticalInput, Time.deltaTime / movementThresold);
        transform.Rotate(0.0f, steerFactor * steerSpeed, 0.0f);
    }
}
