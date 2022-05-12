using UnityEngine;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
