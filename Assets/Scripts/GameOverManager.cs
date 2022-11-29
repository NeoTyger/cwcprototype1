using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class GameOverManager : MonoBehaviour
{
    
    private CanonController _canonController;

    [SerializeField] private Button _btnReturnMenu;
    [SerializeField] private Button _btnRestartLevel1;
    [SerializeField] private Button _btnRestartLevel2;
    [SerializeField] private Button _btnExitGame;
    
    // Start is called before the first frame update
    void Start()
    {
        _btnReturnMenu.onClick.AddListener(ReturnMenu);
        _btnRestartLevel1.onClick.AddListener(RestartLevel1);
        _btnRestartLevel2.onClick.AddListener(RestartLevel2);
        _btnExitGame.onClick.AddListener(ExitGame);
    }

    private void ReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void RestartLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    
    private void RestartLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
