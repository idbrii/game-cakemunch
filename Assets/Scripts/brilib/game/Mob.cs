using UnityEngine;
using System.Collections;

// A moveable object with a max speed and forced movement amounts. Does not
// obey AddForce.
public class Mob : MonoBehaviour
{
    [Tooltip("The speed of the actor")]
    public Vector2 speed = new Vector2(10, 10);
    
    private Vector2 movement;


    protected void HaltMovement()
    {
        movement = new Vector2(0.0f, 0.0f);
    }

    protected void UpdateMovement(float inputX, float inputY)
    {
        movement = new Vector2(
                speed.x * inputX,
                speed.y * inputY);
    }

    // A laggy move to target. This function is useful when you're trying to
    // move somewhere specific and not just in a direction. It will avoid
    // oscillating around your destination.
    protected void UpdateMoveIntention(Vector2 desiredPosition)
    {
        float x = Mathf.MoveTowards(transform.position.x, desiredPosition.x, speed.x);
        float y = Mathf.MoveTowards(transform.position.y, desiredPosition.y, speed.y);
        x = x - transform.position.x;
        y = y - transform.position.y;

        movement = new Vector2(x, y);
    }

    // A snappier move to target that still respects 'speed'. Instead of using
    // velocity, force the transform to our desired position. Useful when you
    // don't want to lag caused by acceleration in physics. With really small
    // values of speed (0.1), this function produces some soft but strict
    // following behaviour.
    protected void ForceMoveIntention_SkipPhysics(Vector2 desiredPosition)
    {
        float x = Mathf.MoveTowards(transform.position.x, desiredPosition.x, speed.x);
        float y = Mathf.MoveTowards(transform.position.y, desiredPosition.y, speed.y);

        transform.position = new Vector2(x, y);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}

