using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class EnemyGenerator : MonoBehaviour
{
    public UnityAction<int> onGiveReward; 

    [SerializeField] private GameObject[] enemiesPrefab;
    [SerializeField] private Transform[] spawnPoint;

    private void SpawnEnemy(float delay)
    {
        if(enemiesPrefab != null && spawnPoint!= null)
        {
            int rndPrefab = Random.Range(0, enemiesPrefab.Length);
            int rndSpawn = Random.Range(0, spawnPoint.Length);
            GameObject newEnemy = Instantiate(enemiesPrefab[rndPrefab], spawnPoint[rndSpawn].position, Quaternion.identity);
            newEnemy.SetActive(false);
            StartCoroutine(SpawnDelay(delay, newEnemy));
        }
    }

    public void BeginOffensive(int enemiesNumber)
    {
        for (int i = 0; i < enemiesNumber; i++)
        {
            SpawnEnemy(i);
        }        
    }

    private IEnumerator SpawnDelay(float delay, GameObject delyedObject)
    {
        yield return new WaitForSeconds(delay);
        delyedObject.SetActive(true);
    }
   

   

    private void EnemyKilled(Enemy enemy, int reward)
    {
        onGiveReward?.Invoke(reward);
    }

    private void OnEnable()
    {
        Enemy.OnEnemyDestroy += EnemyKilled;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDestroy -= EnemyKilled;
    }

   
}
