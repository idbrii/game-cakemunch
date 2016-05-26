using UnityEngine;
using System.Collections;

public class MunchPlayerControl : PlayerControl
{
    [Tooltip("Name for Shoot action input")]
    public string ShootInput = "Fire";

    /*
    protected override void UpdateMovement(float inputX, float inputY)
    {
        base.UpdateMovement(inputX, inputY);
        */

    void Update()
    {
        // Retrieve axis information for movement
        float inputX = Input.GetAxis(HorizontalInput);
        float inputY = Input.GetAxis(VerticalInput);

        UpdateMovement(inputX, inputY);


        // Button information for actions
        bool isShooting = Input.GetButton(ShootInput);
        if (isShooting) {
            GetComponent<BallHandler>().RequestShoot(inputX, inputY);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    }
}

