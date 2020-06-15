using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Manager Handlers")]
    private AudioManager audioManager;

    private bool canFire = false;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>(); //AudioManager is a Singleton
    }

    void Update()
    {
        if (canFire)
        {
            Fire();
        }
            
    }

    void Fire()
    {
        GameObject bullet = null;
        
        if (canFire)
        {

            bullet = BulletPooler.current.GetPooledObject(false);                // Get a new bullet from the bullets pool
        }
        //else if (backFire)
        //{
        //    bullet = BulletPooler.current.GetPooledObject(true);                // Get a new bullet from the bullets pool
        //}

        if (bullet == null) { return; }

        bullet.transform.position = this.transform.position;                       // Place the Normal Bullet on the Gun Container
        bullet.SetActive(true);
        audioManager.PlayBulletShot();

        canFire = !canFire; //Reverse boolean
    }

    public void FireButtonDown()
    {
        canFire = true;
    }

    public void FireButtonUp()
    {
        canFire = false;
    }
}
