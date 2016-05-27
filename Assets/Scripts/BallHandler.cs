using UnityEngine;
using System.Collections;

public class BallHandler : MonoBehaviour {

    [Tooltip("The ball object for the game that we use to score.")]
    public Transform ball;

    [Tooltip("The object we're shooting at to get points.")]
    public Transform scoreTarget;
    [Tooltip("The reflection object that's above us.")]
    public Transform upperReflection;
    [Tooltip("The reflection object that's below us.")]
    public Transform lowerReflection;

    [Tooltip("The speed we throw/shoot the ball.")]
    public float shootingVelocity = 1;
    
    
    bool isBallAttached = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // On collision with ball, attach it to ourselves.
        if (collision.gameObject.transform == ball) {
            AttachBall();
        }
    }

    public void RequestShoot(float inputX, float inputY) {
        Debug.Log(string.Format("RequestShoot isBallAttached={0} inputY={1}", isBallAttached, inputY), this);
        if (isBallAttached) {
            if (Mathf.Approximately(inputY, 0.0f)) {
                // If no inputY, then shoot towards opponent's goal.
                ShootAt(scoreTarget);
            }
            // Otherwise, shoot it towards reflection in corresponding inputY
            // direction. 
            else if (inputY > 0) {
                ShootAt(upperReflection);
            }
            else { // inputY < 0
                ShootAt(lowerReflection);
            }
        }
    }

    private void ShootAt(Transform target)
    {
        DetachBall();

        // launch it at target.
        Vector2 direction = target.position - ball.transform.position;
        direction.Normalize();
        direction *= shootingVelocity;

        ball.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
        Debug.Log(string.Format("ShootAt {0}", direction), target.gameObject);
    }

    private void AttachBall()
    {
        if ( !isBallAttached )
        {
            isBallAttached = true;
            Debug.Log("AttachBall", this);
        }
    }

    private void DetachBall()
    {
        isBallAttached = false;
        Debug.Log("DetachBall", this);
    }
}
