using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking.Types;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public VehicleCrossGoal crossGoal;

    public static GameManager instance;

    private CanonController _canonController;

    private float life = 100.0f;
    public int sceneLevel = 0;
    public bool youWin = false;
    private int ptsCount = 0;

    [SerializeField] private TextMeshProUGUI _txtPoints;
    public TextMeshProUGUI _txtWinner;
    public Button _btnOk;
    [SerializeField] private GameObject _player;
    [SerializeField] private Slider _lifebar;

    private List<GameObject> _enemies;
    private List<GameObject> _obstacles;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        _canonController = FindObjectOfType<CanonController>();

        _enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        _obstacles = new List<GameObject>(GameObject.FindGameObjectsWithTag("Obstacle"));
    }

    public void GameOver()
    {
        if (sceneLevel == 1 && youWin)
        {
            youWin = false;
            _player.transform.position = new Vector3(0, 0, 0);
            PlayerPrefs.SetInt("level", 2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level2");
        }
        else //si el nivel sigue siendo el primero y has perdido GameOver
        {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Game Over");
        }
    }

    public void AddDamage(float totalDamage)
    {
        life -= totalDamage;
        _lifebar.value = life;

        if (life <= 0.0f)
        {
            Destroy(_player);
            FinishLevel("YOU DIE");
            youWin = false;
        }
    }

    public void AddHeal()
    {
        if (life < 100.0f)
        {
            life = 100.0f;
            _lifebar.value = life;
        }
        
    }
    
    private void FinishLevel(string message)
    {
        _txtWinner.gameObject.SetActive(true);
        _txtWinner.text = message;
        _btnOk.gameObject.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        _canonController.enabled = false;

        //Pausa
        Time.timeScale = 0;
    }

    public void TargetHitAddPoints(GameObject gameObj)
    {
        if (_enemies.Contains(gameObj) )
        {
            ptsCount += 100;
            _txtPoints.text = "Pts: " + ptsCount;
            _enemies.Remove(gameObj);
            Destroy(gameObj);
        }

        else if (_obstacles.Contains(gameObj))
        {
            ptsCount += 50;
            _obstacles.Remove(gameObj);
            _txtPoints.text = "Pts: " + ptsCount;
            Destroy(gameObj);
        }
    }

    public void Winner()
    {
        youWin = true;
        FinishLevel(_txtWinner.text);
    }
    
}
