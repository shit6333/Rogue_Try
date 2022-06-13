using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnEnemys;    // Enemy List

    public float spawnTime = 1f;
    public int generateMaxAmount = 2;   // 生成數量 range
    public float generateMaxRange = 3f; // 生成位置 range
    
    private float generatePosX;
    private float generatePosY;
    private int prefabNum = 0;      // 生成物件數量
    private bool isSpawn = true;   // 是否生成
    private GameObject spawnEnemy;  // 要生成的 Enemy
    private int spawnCount = 0;     // 所有 Enemy 種類數量
    private int leastSpawnNum = 0;  // 最少一次生成數量
    private int generateAmount = 0;

    private void Start()
    {
        spawnCount = spawnEnemys.Length;
        generateAmount = generateMaxAmount;
    }

    private void FixedUpdate()
    {
        if (isSpawn)
        {
            // 計時(生成間隔時間)
            StartCoroutine("Wait");
            // 生成敵人
            if(GameManager.canSpawn)
                GeneratePrefab();
            isSpawn = false;
        }
    }

    // 生成函數
    private void GeneratePrefab(){
        // 隨機選擇要產生的 Enemy
        int enemyIndex = Random.Range(0, spawnCount);
        spawnEnemy = spawnEnemys[enemyIndex];

        // 不同 Enemy 生成數量 range
        if (enemyIndex == 0)
        {
            generateAmount = generateMaxAmount;
            leastSpawnNum = 0;
        }
        if (enemyIndex == 1)
        {
            leastSpawnNum = 3;          // 以後還會做更動 !!!!!!!!!!!!!!!!!!!
            generateAmount = 10;       //  TODO : 用成變數或另外設置
        }

        // 生成隨機數量
        prefabNum = Random.Range(leastSpawnNum, generateAmount);

        for (int i = 0; i < prefabNum; i++)
        {
            generatePosX = Random.Range(-generateMaxRange, generateMaxRange);
            generatePosY = Random.Range(-generateMaxRange, generateMaxRange);
            GameObject spawnPrefab =  Instantiate(spawnEnemy, new Vector3( transform.position.x + generatePosX,
                                                  transform.position.y + generatePosY, 0), Quaternion.identity);
            GameManager.allEnemysList.Add(spawnPrefab);
        }
    }

    // 生成間隔時間
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(spawnTime);
        isSpawn = true;
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(generateMaxRange * 2, generateMaxRange * 2, 0));
    }
    
}
