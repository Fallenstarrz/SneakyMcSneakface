using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    // Variables
    public float viewDistance;
    [Range(0, 360)]
    public float fieldOfView;

    // Components
    private Transform tf;

    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    public bool inLineOfSight(GameObject player)
    {
        Collider2D targetCollider = player.GetComponent<Collider2D>();
        if (targetCollider == null)
        {
            return false;
        }

        Transform targetTransform = player.GetComponent<Transform>();
        Vector3 vectorToTarget = targetTransform.position - tf.position;

        float angle = Vector3.Angle(vectorToTarget, tf.right);

        if (angle >= fieldOfView)
        {
            return false;
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(tf.position, vectorToTarget, viewDistance);
        Debug.DrawRay(tf.position, vectorToTarget, Color.red, viewDistance);

        if (hitInfo.collider == null)
        {
            return false;
        }

        if (hitInfo.collider == targetCollider)
        {
            return true;
        }

        return false;
    }
}
