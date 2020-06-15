using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float bulletSpeed = 25; //Bullet Speed default value to 25, exposed on Inspector to tune it if needed.

    void Update()
    {
        this.transform.position += Vector3.right * bulletSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
