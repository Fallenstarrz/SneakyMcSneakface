using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    [SerializeField]
    protected int MoveSpeed;
    [SerializeField]
    protected int RotationSpeed;

    protected float moveDirection;
    protected float rotateDirection;

   // public Component NoiseMaker;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        move();
        rotate();
    }

    void move()
    {
        transform.Translate(0, moveDirection * Time.deltaTime * MoveSpeed, 0);
    }

    void rotate()
    {
        transform.Rotate(0, 0, rotateDirection * Time.deltaTime * RotationSpeed);
    }
}
