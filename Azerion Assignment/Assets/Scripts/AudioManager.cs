using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource musicPlayer;

    static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        if (musicPlayer)
            musicPlayer.Play();
    }

}
