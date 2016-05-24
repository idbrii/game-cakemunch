using UnityEngine;
using System.Collections;

public class ReflectionMovement : Mob {

    [Tooltip("The object we're reflecting.")]
    public Transform original;

    void Update() {
        ForceMoveIntention_SkipPhysics(new Vector2(original.position.x, transform.position.y));

        // This also works, but is much laggier.
        //UpdateMoveIntention(new Vector2(original.position.x, transform.position.y));
    }
}
