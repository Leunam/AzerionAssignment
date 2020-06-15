using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPooler : MonoBehaviour {


    // ==============================
    // New Method to Pool the Bullets
    // ==============================
    public static BulletPooler current;
    public GameObject pooledBulletObject;
    public int pooledBulletsAmount = 20;
    public bool willGrow = true;

    public List<GameObject> pooledBulletObjects;

    void Awake()
    {
        current = this;
    }

	void Start () {
        // New method to pool the bullets.
        // Create a new list of bullets with 'pooledBulletsAmount' bullets on it.
        pooledBulletObjects = new List<GameObject>();
        for (int i = 0; i < pooledBulletsAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledBulletObject);
            obj.transform.parent = current.transform;
            obj.SetActive(false);
            pooledBulletObjects.Add(obj);
        }

	}

    public GameObject GetPooledObject(bool _backfire)
    {
        for (int i = 0; i < pooledBulletObjects.Count; i++)
        {
            if (!pooledBulletObjects[i].activeInHierarchy)
            {
                if(_backfire)
                    pooledBulletObjects[i].transform.rotation = new Quaternion(0, 180, 0, 0);
                else
                    pooledBulletObjects[i].transform.rotation = new Quaternion(0, 0, 0, 0);
                return pooledBulletObjects[i];
            }
        }
        // If we need more bullets for whatever reason we expand the pool of bullets creating a new bullet and adding it to the pool.
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledBulletObject);
            obj.transform.parent = current.transform;
            pooledBulletObjects.Add(obj);
            if (_backfire)
                obj.transform.rotation = new Quaternion(0, 180, 0, 0);
            else
                obj.transform.rotation = new Quaternion(0, 0, 0, 0);
            return obj;
        }

        return null;
    }
}
