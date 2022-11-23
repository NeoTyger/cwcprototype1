using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCrossesGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("WINNER!!!");
        }
    }
}
