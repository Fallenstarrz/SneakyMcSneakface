using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    // Variables
    public float viewDistance;
    [Range(0, 360)]
    public float fieldOfView;

    // What is the AI looking for
    public GameObject target;

    public bool inLineOfSight()
    {

        Vector3 vectorToTarget = target.transform.position - transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, vectorToTarget, viewDistance);
        Hitbox targetCollider = target.GetComponent<Hitbox>();
        float angle = Vector3.Angle(vectorToTarget, transform.up / 2);

        if (targetCollider == null)
        {
            return false;
        }
        if (hitInfo.collider == null)
        {
            return false;
        }
        if (angle <= fieldOfView)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < viewDistance)
            {
                if (hitInfo.collider.name == targetCollider.name)
                {
                    return true;
                }
            }
        }
            return false;
    }
}
