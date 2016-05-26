using UnityEngine;
using System.Collections;

public class PlayerControl : Mob
{
    // These need to match Unity's InputManager.
    [Tooltip("Name for Horizontal movement input axis")]
    public string HorizontalInput = "Horizontal";
    [Tooltip("Name for Vertical movement input axis")]
    public string VerticalInput = "Vertical";
    

    protected void HandleMovementInput()
    {
        // Retrieve axis information for movement
        float inputX = Input.GetAxis(HorizontalInput);
        float inputY = Input.GetAxis(VerticalInput);

        UpdateMovement(inputX, inputY);
    }

    // For basic functionality, add this method to your subclass:
    //void Update()
    //{
    //    HandleMovementInput();
    //}

    // You probably want to override these:
    //void Awake()
    //void OnCollisionEnter2D(Collision2D collision)
    //void UpdateMovement(float inputX, float inputY)
}

