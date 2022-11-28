using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

    private CanonController _canonController;
    private VehicleMovement _vehicleMovement;
    
    [SerializeField] private Button _btnReturnMenu;
    [SerializeField] private Slider _audioSlider;
    [SerializeField] private Slider _playerSpeedSlider;
    [SerializeField] private Slider _bulletSpeedSlider;

    private bool sliderSelect = false;

    private void Start()
    {
        _canonController = FindObjectOfType<CanonController>();
        _vehicleMovement = FindObjectOfType<VehicleMovement>();
        
        _btnReturnMenu.onClick.AddListener(ReturnMenu);
        
    }
    
    private void ReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SliderSelected()
    {
        sliderSelect = true;
    }

    public void SliderNotSelected()
    {
        sliderSelect = false;
    }

    private void Update()
    {
        //_audioSlider.value = 
        //_playerSpeedSlider.value = _vehicleMovement.speed;
        //_bulletSpeedSlider.value = _canonController.bulletSpeed;

        float sliderPercentagePlayer = _playerSpeedSlider.value;
        float sliderPercentageBullet = _bulletSpeedSlider.value;
        
        
        if (!sliderSelect)
        {
            _playerSpeedSlider.value = sliderPercentagePlayer;
            _bulletSpeedSlider.value = sliderPercentageBullet;
        }

    }
}
