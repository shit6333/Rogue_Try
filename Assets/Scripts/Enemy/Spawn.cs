using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawnEnemys;    // Enemy List

    public float spawnTime = 1f;
    public int generateMaxAmount = 2;   // �ͦ��ƶq range
    public float generateMaxRange = 3f; // �ͦ���m range
    
    private float generatePosX;
    private float generatePosY;
    private int prefabNum = 0;      // �ͦ�����ƶq
    private bool isSpawn = true;   // �O�_�ͦ�
    private GameObject spawnEnemy;  // �n�ͦ��� Enemy
    private int spawnCount = 0;     // �Ҧ� Enemy �����ƶq
    private int leastSpawnNum = 0;  // �̤֤@���ͦ��ƶq
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
            // �p��(�ͦ����j�ɶ�)
            StartCoroutine("Wait");
            // �ͦ��ĤH
            if(GameManager.canSpawn)    // ���W�ĤH�ƶq�S�W�L����
                GeneratePrefab();
            isSpawn = false;
        }
    }

    // �ͦ����
    private void GeneratePrefab(){
        // �H����ܭn���ͪ� Enemy
        int enemyIndex = Random.Range(0, spawnCount);
        spawnEnemy = spawnEnemys[enemyIndex];

        // ���P Enemy �ͦ��ƶq range
        if (enemyIndex == 0)
        {
            generateAmount = generateMaxAmount;
            leastSpawnNum = 0;
        }
        if (enemyIndex == 1)
        {
            leastSpawnNum = 3;          // �H���ٷ|����� !!!!!!!!!!!!!!!!!!!
            generateAmount = 10;       //  TODO : �Φ��ܼƩΥt�~�]�m
        }

        // �ͦ��H���ƶq
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

    // �ͦ����j�ɶ� // �����S�O�I�s !
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
