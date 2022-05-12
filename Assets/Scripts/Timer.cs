using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText; //serialize é o mesmo que privado mas aparece na unity para receber var
    float startingTime = 60;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime; //diminuir 1 a cada segundo

        if (currentTime >= 10)
            timerText.text = currentTime.ToString("0"); //o 0 é para não mostrar casas decimais
        else
            timerText.text = "0" + currentTime.ToString("0");

        if (currentTime <= 0) //CASO DE DERROTA: o timer zerou e o player não completou a corrida
            SceneManager.LoadScene("youLose");

    }
}
