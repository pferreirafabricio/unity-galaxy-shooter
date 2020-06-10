using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isCoopMode = false;
    public bool GameOver = true;
    public GameObject _PlayerPrefab;

    [SerializeField]
    private GameObject _CoopPlayers;

    private UIManager _uiManager;
    private SpawnManager _spawnManager;

    public GameObject pauseMenu;

    [SerializeField]
    private Animator _pauseAnimator;

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _pauseAnimator = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>();
        _pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    private void Update()
    {
        if (GameOver == true)
        {
            _uiManager.ShowTitleScreen();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isCoopMode == false)
                {
                    Instantiate(_PlayerPrefab, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Instantiate(_CoopPlayers, Vector3.zero, Quaternion.identity);
                }
                
                GameOver = false;
                _uiManager.HideTitleScreen();
                _spawnManager.StartSpawnRoutine();
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(true);
            _pauseAnimator.SetBool("isPaused", true);
            Time.timeScale = 0f;
        }
    }
}
