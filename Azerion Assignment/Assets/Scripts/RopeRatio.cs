﻿using UnityEngine;
using System.Collections;

public class RopeRatio : MonoBehaviour
{

    public GameObject player;
    public Vector3 grabPos;
    public float ratio;

    void Update()
    {
        float scaleX = Vector3.Distance(player.transform.position, grabPos) / ratio;
        GetComponent<LineRenderer>().material.mainTextureScale = new Vector2(scaleX, 1f);
    }
}