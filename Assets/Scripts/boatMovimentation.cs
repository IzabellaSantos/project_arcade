using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boatMovimentation : MonoBehaviour
{
    float z, x, powerUpTime;
    public float velocity;
    [SerializeField] Text velocityText;
    int countCollisonLine;

    void Start()
    {
        velocity = 10;
        countCollisonLine = 0;
        powerUpTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        z = Input.GetAxis("Vertical") * velocity;
        x = Input.GetAxis("Horizontal") * velocity;

        if (z != 0 || x != 0)
            transform.Translate(x * Time.deltaTime, 0, z * Time.deltaTime);

        velocityText.text = velocity.ToString("0") + " km/h"; // mostra a velocidade atual do barco

        //regulagem de velocidade quando pega o powerUp (gasolina)
        if (powerUpTime >= 0)
            powerUpTime -= 1 * Time.deltaTime;
        else
            velocity = 10;

        //muda a cor quando você tem um powerUp ativo
        if (velocity >= 20)
            velocityText.color = Color.green;
        else
            velocityText.color = Color.white;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject); //destroi a gasolina
            velocity += 10; //adicionar o tempo
            powerUpTime = 5;
        }
        else if (collision.gameObject.CompareTag("finishLine"))
        {
            countCollisonLine += 1;

            if (countCollisonLine == 2)
                SceneManager.LoadScene("youWin");
        }
    }
}
