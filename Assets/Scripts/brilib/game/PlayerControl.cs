using UnityEngine;
using System.Collections;

public class PlayerControl : Mob
{
    // These need to match Unity's InputManager.
    [Tooltip("Name for Horizontal input axis")]
    public string HorizontalInput = "Horizontal";
    [Tooltip("Name for Vertical input axis")]
    public string VerticalInput = "Vertical";
    

    void Update()
    {
        // Retrieve axis information
        float inputX = Input.GetAxis(HorizontalInput);
        float inputY = Input.GetAxis(VerticalInput);

        UpdateMovement(inputX, inputY);
    }

    // You probably want to override these:
    //void Awake()
    //void OnCollisionEnter2D(Collision2D collision)
    //void UpdateMovement(float inputX, float inputY)
}

