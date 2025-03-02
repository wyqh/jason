using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int currentLevel = 1;
    public int maxLevel = 10;
    public int enemiesPerLevel = 10;
    public int remainingEnemies;
    public bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartLevel()
    {
        remainingEnemies = enemiesPerLevel;
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        for (int i = 0; i < enemiesPerLevel; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2f);
        }
    }

    private void SpawnEnemy()
    {
        // 在地图四周随机生成敌人
        float randomSide = Random.Range(0, 4);
        Vector3 spawnPosition = Vector3.zero;
        
        // 根据随机值决定在哪个边生成敌人
        switch (randomSide)
        {
            case 0: // 上边
                spawnPosition = new Vector3(Random.Range(-10f, 10f), 0, 10f);
                break;
            case 1: // 右边
                spawnPosition = new Vector3(10f, 0, Random.Range(-10f, 10f));
                break;
            case 2: // 下边
                spawnPosition = new Vector3(Random.Range(-10f, 10f), 0, -10f);
                break;
            case 3: // 左边
                spawnPosition = new Vector3(-10f, 0, Random.Range(-10f, 10f));
                break;
        }
        
        // 这里需要预制件引用
        // Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
} 