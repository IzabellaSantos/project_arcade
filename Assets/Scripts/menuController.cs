using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class menuController : MonoBehaviour
{
    List<int> widths = new List<int>() { 1920, 1280, 960, 568 };
    List<int> heights = new List<int>() { 1080, 800, 540, 320 };
    public void startButton()
    {
        SceneManager.LoadScene("firstLevel");
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void setScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void setFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }


}
