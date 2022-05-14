using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boatCollision : MonoBehaviour
{
    private float powerUpTime;
    private bool hasCollide = false;
    private int countCollisonLine;
    [SerializeField] Text speedText, turnText;
    GameObject player;
    playerStatus boat;
    Scene scene;

    private void Start()
    {
        player = GameObject.FindWithTag("Player"); //acha o player
        boat = player.GetComponent<playerStatus>();
        scene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        speedText.text = boat.speed.ToString("0") + "0 km/h"; // mostra a velocidade atual do barco

        if (player.name == "simpleBoat")
        {
            //regulagem de velocidade quando pega o powerUp (gasolina)
            if (powerUpTime >= 0)
                powerUpTime -= 1 * Time.deltaTime;
            else
                boat.speed = 1;

            //muda a cor quando você tem um powerUp ativo
            if (boat.speed >= 2)
                speedText.color = Color.green;
            else
                speedText.color = Color.white;
        }
    }

    private void LateUpdate()
    {
        hasCollide = false;
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.gameObject.CompareTag("Item"))
        {
            if (hasCollide == false)
            {
                hasCollide = true;

                Destroy(otherObject.gameObject);
                Sounds.PlaySound("item");
                boat.fuel += 30;

                if (player.name == "simpleBoat")
                { //ganha velocidade se for o simple boat
                    boat.speed += 1;
                    powerUpTime = 3;
                }
            }
        }
        else if (otherObject.gameObject.CompareTag("finishLine"))
        {
            turnText.text = countCollisonLine.ToString("0") + "/2";
            countCollisonLine += 1;

            if (countCollisonLine == 3)
                SceneManager.LoadScene("youWin");
        }

    }
}
