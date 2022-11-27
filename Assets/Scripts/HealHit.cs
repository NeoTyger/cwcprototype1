using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealHit : MonoBehaviour
{

    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.AddHeal();
            Destroy(gameObject);
        }
    }
}
