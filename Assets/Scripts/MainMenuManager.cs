using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private Button _btnPlayGame;
    
    // Start is called before the first frame update
    void Start()
    {
        _btnPlayGame.onClick.AddListener(StartLevel1);
        GameObject gameManager = GameObject.Find("Game Manager");

        if (gameManager != null)
        {
            Destroy(gameManager);
        }
    }

    private void StartLevel1()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level1");
    }
}
