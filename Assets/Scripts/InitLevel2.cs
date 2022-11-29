using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLevel2 : MonoBehaviour
{
    
    private CanonController _canonController;
    private GameManager _gameManager;
    
    private void Start()
    {
        _canonController = FindObjectOfType<CanonController>();
    }

    private void StartLevel()
    {
        if (_canonController.enabled == false)
        {
            _canonController.enabled = true;
        }
        _gameManager.youWin = false;
        _gameManager._txtWinner.gameObject.SetActive(false);
        _gameManager._btnOk.onClick.AddListener(_gameManager.GameOver);
        _gameManager._btnOk.gameObject.SetActive(false);
        Time.timeScale = 1.0f;//Quita el pausa

        if (!PlayerPrefs.HasKey("level"))
        {
            _gameManager.sceneLevel = 2;
            PlayerPrefs.SetInt("level", _gameManager.sceneLevel);
            PlayerPrefs.Save();
        }
        else
        {
            _gameManager.sceneLevel = PlayerPrefs.GetInt("level");
        }
    }
}
