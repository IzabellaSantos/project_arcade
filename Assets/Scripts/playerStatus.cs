using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStatus : MonoBehaviour
{
    public float health;
    public float fuel;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        fuel = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        fuel -= 1 * Time.deltaTime;
        if (fuel <= 0)
            SceneManager.LoadScene("youLose");

        if (fuel > 100)
            fuel = 100;
    }
}
