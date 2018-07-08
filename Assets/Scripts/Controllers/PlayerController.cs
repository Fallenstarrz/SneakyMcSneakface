using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        inputHandler();
    }

    void inputHandler()
    {
        if (Input.GetButton("Attack"))
        {
            moveDirection = 1.0f;
            pawn.attack();
        }
        if (Input.GetButton("MoveForward"))
        {
            moveDirection = 1.0f;
            pawn.move(moveDirection);
        }
        if (Input.GetButton("MoveBackward"))
        {
            moveDirection = -1.0f;
            pawn.move(moveDirection);
        }
        if (Input.GetButton("MoveLeft"))
        {
            rotateDirection = 1.0f;
            pawn.rotate(rotateDirection);
        }
        if (Input.GetButton("MoveRight"))
        {
            rotateDirection = -1.0f;
            pawn.rotate(rotateDirection);
        }
    }
}
