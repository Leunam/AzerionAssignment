using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object
    public Vector3 offset;            //Private variable to store the offset distance between the player and camera
    public float yOffset = 0.5f;
    public PlayerPlatformerController playerController;
    private bool offsetChanged = false;
    private bool offsetRestored = false;
    void Start()
    {
        //if (!playerController)
        //    playerController = FindObjectOfType<PlayerPlatformerController>();
     
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        //if (playerController.GetGrounded() && !offsetChanged)
        //{
        //    IncreaseYOffset();
        //    offsetChanged = true;
        //    Debug.Log("how many times?");
        //}
        
        //if (!playerController.GetGrounded() && !offsetRestored && offsetChanged)
        //{
        //    RestoreYOffset();
        //    offsetChanged = false;
        //    Debug.Log("how many times 2?");
        //}
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }

    //public void IncreaseYOffset()
    //{
    //    offset = player.transform.position + new Vector3(offset.x, offset.y + yOffset, 0);
    //    Debug.Log("offset = " + offset.ToString());
    //}

    //public void RestoreYOffset()
    //{
    //    offset = player.transform.position + new Vector3(offset.x, offset.y - yOffset, 0);
    //}
}