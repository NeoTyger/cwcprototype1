using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCrossGoal : MonoBehaviour
{
    
    public bool winner = false;
    
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            winner = true;
        }
    }
}
