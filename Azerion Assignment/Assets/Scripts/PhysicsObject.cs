using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    public float minGroundNormalY = .65f;
    public float gravityModifier = 0.1f;  //Allow us to modify gravity

    protected Vector2 targetVelocity;
    protected bool grounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);


    protected const float minMoveDistance = 0.001f; //Minimum distance
    protected const float shellRadius = 0.01f; //Some padding to detect the raycasts

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();        
    }

    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer)); //Getting and use the Physics2D layer mask from Project Settings
        contactFilter.useLayerMask = true;
    }

    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;   //Use of the 2d system gravity to modify objects based on our gravityModifier variable.
        velocity.x = targetVelocity.x;

        grounded = false;                                                   //until a collision is registered, grounded is set to false.

        Vector2 deltaPosition = velocity * Time.deltaTime;                  //where is gonna be our object based on the velocity

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();

            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            //Check the normal of each of those raycasts 2d objects to determine the angle of the things hitting them
            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal; //Check the normal of each of our raycasts2d in our list
                //compare them with a minimun value
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
                //we are getting the difference between the velocity and the current normal and 
                //determining wether we need to substract from our velocity to prevent the player from entering another collider
                float projection = Vector2.Dot(velocity, currentNormal); 
                if (projection < 0) //if projection returns a negative number then...
                {
                    velocity = velocity - projection * currentNormal; //cancel out the part of our velocity that will be stop by the collition.
                    
                }
                //before setting the position we check if the collition in our lists distance is less that our shell size constant, to prevent us to get stuck in another collider
                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                //Check if distance is bigger that modifiedDistance, yes -> use modifiedDistance, not -> use distance
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
