using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class boatController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public float motor, steering;
    [SerializeField] Text speedText;
    GameObject player;
    playerStatus boat;
    private float powerUpTime, aumentaVelocidade;
    Transform boatTransform;

    private void Start()
    {
        player = GameObject.FindWithTag("Player"); //acha o player
        boat = player.GetComponent<playerStatus>();
        aumentaVelocidade = 1;
        boatTransform = this.GetComponent<Transform>();
    }

    private void Update()
    {
        speedText.text = (motor / 100).ToString("0") + "km/h"; // mostra a velocidade atual do barco

        //regulagem de velocidade quando pega o powerUp (gasolina)
        if (powerUpTime >= 0)
            powerUpTime -= 1 * Time.deltaTime;

        if (powerUpTime <= 0)
            aumentaVelocidade = 1;

        if (player.name == "simpleBoat")
        {
            //muda a cor quando você tem um powerUp ativo
            if ((motor / 100) > 10)
                speedText.color = Color.green;
            else
                speedText.color = Color.white;
        }

    }

    public void FixedUpdate()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical") * aumentaVelocidade;
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
        }
    }


    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.gameObject.CompareTag("Item"))
        {
            Destroy(otherObject.gameObject);
            Sounds.PlaySound("item");
            boat.fuel += 30;

            if (player.name == "simpleBoat")
            { //ganha velocidade se for o simple boat
                aumentaVelocidade = 3;
                powerUpTime = 3;
            }
        }
    }
}
