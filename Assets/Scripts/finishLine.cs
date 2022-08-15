using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finishLine : MonoBehaviour
{

    private int countCollisonLine;
    [SerializeField] Text turnText;
    GameObject player;
    playerStatus boat;
    Scene scene;
    private int countCheckPoint1, countCheckPoint2, countCheckPoint3;

    private void Start()
    {
        player = GameObject.FindWithTag("Player"); //acha o player
        boat = player.GetComponent<playerStatus>();
        scene = SceneManager.GetActiveScene();
        countCheckPoint1 = 0;
        countCheckPoint2 = 0;
        countCheckPoint3 = 0;
    }


    private void OnTriggerEnter(Collider otherObject)
    {

        if (otherObject.gameObject.CompareTag("checkpoint"))
        {
            if (otherObject.name == "checkpoint1")
            {
                countCheckPoint1 += 1;
            }
            else if (otherObject.name == "checkpoint2")
            {
                countCheckPoint2 += 1;
            }
            else
            {
                countCheckPoint3 += 1;
            }
        }

        if (otherObject.gameObject.CompareTag("finishLine"))
        {
            if (countCheckPoint1 != 0 && countCheckPoint2 != 0 && countCheckPoint3 != 0)
            {
                countCollisonLine += 1;
                turnText.text = countCollisonLine.ToString("0") + "/2";
            }

            if (countCollisonLine == 2)
                SceneManager.LoadScene("youWin");
        }

    }
}
