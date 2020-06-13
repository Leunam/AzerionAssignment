using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource musicPlayer;

    static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    //Manage instance, so we don't have duplicate instance in the scene when loaded.
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        if (musicPlayer)
            musicPlayer.Play();
    }

}
