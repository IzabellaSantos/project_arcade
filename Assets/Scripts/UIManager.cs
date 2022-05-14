using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Image healthBar, fuelBar;
    private float currentHealth, currentFuel;
    private float maxHealth = 100f, maxFuel = 100f;
    playerStatus player;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        fuelBar = GetComponent<Image>();
        player = FindObjectOfType<playerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "life")
        {
            currentHealth = player.health;
            healthBar.fillAmount = currentHealth / maxHealth;
        }
        else if (gameObject.tag == "fuel")
        {
            currentFuel = player.fuel;
            fuelBar.fillAmount = currentFuel / maxFuel;
        }

    }
}
