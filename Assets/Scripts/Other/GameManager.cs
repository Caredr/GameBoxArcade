using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static int currentPoints = 0;
    public Dictionary<GameObject, HealthSystem> healthContainer;

    [SerializeField] private int enemiesOnFirstWave = 3;
    [SerializeField] private float timeToNextWave = 15f;
    [SerializeField] private EnemyGenerator enemyGenerator;

    [SerializeField] private GameObject loseMenu;

    private float timeToSpawn = 1f;

    private int enemiesOnWave;
    private int currentWave;

    public static GameManager Instance
    { get; private set; }


    private void Awake()
    {
        Time.timeScale = 1f;
        loseMenu.SetActive(false);

        Instance = this;
        currentPoints = 0;

        healthContainer = new Dictionary<GameObject, HealthSystem>();

        enemyGenerator.onGiveReward += TakePoints;
    }

    private void FixedUpdate()
    {
        if (timeToSpawn < Time.time)
        {
            StartNextWave();
            timeToSpawn = timeToNextWave + Time.time;
        }
    }

    public void StartNextWave()
    {
        currentWave++;
        enemiesOnWave = enemiesOnFirstWave * currentWave;
        enemyGenerator.BeginOffensive(enemiesOnWave);
    }

    public void TakePoints(int points)
    {
        currentPoints += points;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        loseMenu.SetActive(true);
    }
}
