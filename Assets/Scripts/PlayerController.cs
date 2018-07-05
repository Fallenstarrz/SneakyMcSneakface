using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{

    public CircleCollider2D noiseMaker;
    public float baseNoiseLevel;
    private float moveNoiseLevel = 0.0f;
    private float rotateNoiseLevel = 0.0f;
    private float shootNoiseLevel = 0.0f;
    private float currentNoiseLevel = 0.0f;
    private float[] noiseLevels = new float[3];
    public float soundDecayTimer;

// Use this for initialization
void Start()
    {
        baseNoiseLevel = 1;
        GameManager.instance.player = this.gameObject;
    }

    // Update is called once per frame
    protected override void Update()
    {
        inputHandler();
        makeNoise();
        base.Update();
    }

    void inputHandler()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            moveDirection = Input.GetAxis("Vertical");
            moveNoiseLevel = 1.0f;
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            moveDirection = Input.GetAxis("Vertical");
            moveNoiseLevel = slowlyReduceNoise();
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            rotateDirection = Input.GetAxis("Horizontal");
            rotateNoiseLevel = 0.5f;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            rotateDirection = Input.GetAxis("Horizontal");
            rotateNoiseLevel = slowlyReduceNoise();
        }
        if (Input.GetButton("Shoot"))
        {
            shootNoiseLevel = 5.0f;
        }
        if (Input.GetButton("Shoot") == false)
        {
            shootNoiseLevel = slowlyReduceNoise();
        }

        noiseLevels[0] = moveNoiseLevel;
        noiseLevels[1] = rotateNoiseLevel;
        noiseLevels[2] = shootNoiseLevel;
    }
    void makeNoise()
    {
        currentNoiseLevel = Mathf.Max(noiseLevels);
        noiseMaker.radius = baseNoiseLevel + currentNoiseLevel;
    }
    float slowlyReduceNoise()
    {
        currentNoiseLevel -= Time.deltaTime * soundDecayTimer;
        noiseMaker.radius = baseNoiseLevel + currentNoiseLevel;
        return (currentNoiseLevel);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Debug.Log(other.name as string + " has aggroed you!");
            //switch AI state to pursue!
        }
    }
}
