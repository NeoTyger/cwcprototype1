using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] private Button _btnReturnMenu;

    private void Start()
    {
        _btnReturnMenu.onClick.AddListener(ReturnMenu);
    }
    
    private void ReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
