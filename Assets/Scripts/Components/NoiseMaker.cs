using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{

    [SerializeField]
    private CircleCollider2D noiseMaker;
    [SerializeField]
    private float baseNoiseLevel = 1.0f;
    [SerializeField]
    private float moveNoiseLevel = 0.0f;
    [SerializeField]
    private float rotateNoiseLevel = 0.0f;
    [SerializeField]
    private float attackNoiseLevel = 0.0f;
    [SerializeField]
    private float currentNoiseLevel = 0.0f;
    [SerializeField]
    private float[] noiseLevels = new float[4];
    [SerializeField]
    private float soundDecayTimer;

    //moveNoiseLevel = 1.0f;
    //rotateNoiseLevel = 0.5f;
    //attackNoiseLevel = 5.0f;


    // Use this for initialization
    void Start ()
    {
        noiseMaker = this.gameObject.GetComponent("CircleCollider2D") as CircleCollider2D;
        noiseLevels[0] = baseNoiseLevel;
        noiseLevels[1] = moveNoiseLevel;
        noiseLevels[2] = rotateNoiseLevel;
        noiseLevels[3] = attackNoiseLevel;
    }

    void makeNoise()
    {
        currentNoiseLevel = Mathf.Max(noiseLevels);
        noiseMaker.radius = baseNoiseLevel + currentNoiseLevel;
    }

    float slowlyReduceNoise()
    {
        if (currentNoiseLevel > baseNoiseLevel)
        {
            currentNoiseLevel -= Time.deltaTime * soundDecayTimer;
            noiseMaker.radius = baseNoiseLevel + currentNoiseLevel;
            return (currentNoiseLevel);
        }
        else
        {
            return (currentNoiseLevel);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Hearing" && other.gameObject.transform.parent.tag != this.tag)
        {
            Debug.Log(other.gameObject.transform.parent.name as string + " has aggroed you!");
            //switch AI state to pursue!
        }
    }
}
