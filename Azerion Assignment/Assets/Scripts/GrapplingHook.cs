using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public LineRenderer lineRenderer;
    DistanceJoint2D distanceJoint;
    Vector3 targetPos;
    private RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    public float step = 0.2f;
    public Joystick joystick;

    private bool hookPressed = false;
    private bool hanging = false;

    void Start()
    {
        distanceJoint = GetComponent<DistanceJoint2D>();
        distanceJoint.enabled = false;
        lineRenderer.enabled = false;
    }

    /// <summary>
    /// Called by Event Triggers
    /// </summary>
    public void HookButtonDown()
    {
        hookPressed = true;
    }

    /// <summary>
    /// Called by Event Triggers
    /// </summary>
    public void HookButtonUp()
    {
        hookPressed = false;
        hanging = false;                //Flag bool to false to Character can Shoot again the Grappling Hook
    }

    void Update()
    {

        if (distanceJoint.distance > 1f)
            distanceJoint.distance -= step;

        float joystickMagnitude = joystick.Direction.magnitude;

        float angleToJoystick = Mathf.Atan2(joystick.Direction.x, joystick.Direction.y) ;

        if (hookPressed && !hanging)
        {
            hit = Physics2D.Raycast(transform.position, new Vector2(Mathf.Sin(angleToJoystick), Mathf.Cos(angleToJoystick)), distance, mask);

            if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                hanging = true;
                distanceJoint.enabled = true;
                
                distanceJoint.connectedAnchor = hit.point;

                distanceJoint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                distanceJoint.distance = Vector2.Distance(transform.position, hit.point);

                lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, hit.point);

                lineRenderer.GetComponent<RopeRatio>().grabPos = hit.point;
            }
        }
        
        if (hookPressed)
        {
            lineRenderer.SetPosition(0, transform.position);
         }

        if (!hookPressed)
        {
            distanceJoint.enabled = false;  //Disable the Distance Joint
            lineRenderer.enabled = false;   //Disable the Line Renderer
        }
    }
}
