using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject _player;
    public GameObject bullet;

    private Rigidbody _bulletRB;
    private Vector3 _direction;
    
    public float bulletSpeed = 10.0f;
    
    public float sensitivity = 5.0f;
    
    private Vector3 _angles = Vector3.zero;
    private readonly float _maxAngles = 60.0f;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _bulletRB = GetComponent<Rigidbody>();
        _direction = _player.transform.position - transform.position;
        _bulletRB.velocity = _direction * bulletSpeed;
    }

    private void Update()
    {
        FireDart();

        float rotateHorizontal = Input.GetAxis("Mouse X");

        _angles.y += rotateHorizontal * sensitivity;
        _angles.y = Mathf.Clamp(_angles.y, -_maxAngles, _maxAngles);

        gameObject.transform.rotation = Quaternion.Euler(_angles);
            
    }

    private void FireDart()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = GameObject.FindWithTag("BulletGenerator").transform.position;
        newBullet.transform.rotation = GameObject.FindWithTag("BulletGenerator").transform.rotation;

        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * bulletSpeed;
    }
}
