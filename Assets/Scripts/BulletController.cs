using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public GameManager _gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        _gameManager.TargetHitAddPoints(collision.gameObject);
        Destroy(gameObject);
    }
}
