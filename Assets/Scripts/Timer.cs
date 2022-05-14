using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText; //serialize é o mesmo que privado mas aparece na unity para receber var
    float startingTime = 120;
    float currentTime;
    int minutes, seconds;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {

        currentTime -= 1 * Time.deltaTime; //diminuir 1 a cada segundo
        minutes = Mathf.FloorToInt(currentTime / 60F);
        seconds = Mathf.FloorToInt(currentTime - minutes * 60);

        if (currentTime < 11)
            timerText.color = Color.red;


        if (seconds <= 9)
            timerText.text = "0" + minutes + ":0" + seconds;
        else
            timerText.text = "0" + minutes + ":" + seconds;



        if (currentTime <= 0) //CASO DE DERROTA: o timer zerou e o player não completou a corrida
            SceneManager.LoadScene("youLose");

    }
}
