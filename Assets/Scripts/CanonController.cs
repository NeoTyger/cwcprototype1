using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour
{
    
    public GameObject bullet;
    public float bulletSpeed = 10.0f;
    
    public float sensitivity = 5.0f;
    
    private Vector3 _angles = Vector3.zero;
    private readonly float _maxAngles = 60.0f;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
        {
            FireDart();
        }
        
        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;

            float rotateHorizontal = Input.GetAxis("Mouse X");

            _angles.y += rotateHorizontal * sensitivity;
            _angles.y = Mathf.Clamp(_angles.y, -_maxAngles, _maxAngles);

            gameObject.transform.rotation = Quaternion.Euler(_angles);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void FireDart()
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = GameObject.FindWithTag("BulletGenerator").transform.position;
        newBullet.transform.rotation = GameObject.FindWithTag("BulletGenerator").transform.rotation;

        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * bulletSpeed;
    }
}
