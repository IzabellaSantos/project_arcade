using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public void startButton()
    {
        SceneManager.LoadScene("firstLevel");
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
