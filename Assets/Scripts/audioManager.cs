using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{

    [SerializeField] private Slider volumeSlider = null;

    void Start()
    {
        LoadValues();
    }

    // Update is called once per frame
    void Update()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);

    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;

    }

}
