using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    // Check if player entered victory trigger box
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            GameManager.instance.sceneScript.LoadCredits();
        }
    }
}
