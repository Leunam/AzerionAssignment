using UnityEngine;
using System.Collections;

/// <summary>
/// Simple script to rotate objects
/// </summary>
public class RotateMe : MonoBehaviour
{
    public float rotationSpeed;
    public bool anticlockwise;

    private float direction;

    void Start()
    {
        if (anticlockwise)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        rotationSpeed = rotationSpeed * direction;
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
