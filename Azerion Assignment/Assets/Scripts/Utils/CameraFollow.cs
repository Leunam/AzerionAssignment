using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object
    public Vector3 offset;           
    public PlayerPlatformerController playerController;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}