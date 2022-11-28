using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCrossGoal : MonoBehaviour
{
    private GameManager _gameManager;
    
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _gameManager.Winner();
        }
    }
}
