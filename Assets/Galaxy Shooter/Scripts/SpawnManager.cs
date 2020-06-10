using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private GameObject[] PowerUps;

    private GameManager _gameManager;

    //public Player player;

	void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
          
	}

    public void StartSpawnRoutine()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    private IEnumerator EnemySpawnRoutine()
    {
        while (_gameManager.GameOver == false)
        {
            Instantiate(EnemyPrefab, new Vector3(Random.Range(-7.6f, 7.6f), 6.43f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5);
        }
    }

    private IEnumerator PowerUpSpawnRoutine()
    {
        while (_gameManager.GameOver == false)
        {
            int RandomPowerUp = Random.Range(0, 3);
            Instantiate(PowerUps[RandomPowerUp], new Vector3(Random.Range(-7.6f, 7.6f), 6.43f, 0), Quaternion.identity);

            yield return new WaitForSeconds(5);
        }
    }
}
