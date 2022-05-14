using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public static AudioClip item;
    public static AudioClip buttonSound;

    public static AudioSource audioComponent;
    //private static float volume = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        item = Resources.Load<AudioClip>("item");
        buttonSound = Resources.Load<AudioClip>("buttonSound");

        audioComponent = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "item":
                audioComponent.PlayOneShot(item);
                break;

            case "buttonSound":
                audioComponent.PlayOneShot(buttonSound);
                break;
        }
    }
}
