using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSources")]
    public AudioSource musicPlayer;
    public AudioSource sfxPlayer;

    [Header("Audio FX")]
    public AudioClip bulletShotSFX;

    //Singleton creation statements.
    static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    //Manage instance, so we don't have a duplicate instance in the scene when loaded.
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

    public void PlayBulletShot()
    {
        sfxPlayer.PlayOneShot(bulletShotSFX);
    }

}
