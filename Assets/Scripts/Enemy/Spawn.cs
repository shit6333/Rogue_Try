using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnTime = 1f;
    public int generateAmount = 2;   // 生成數量 range
    public float generateMaxRange = 3f; // 生成位置 range
    
    private float generatePosX;
    private float generatePosY;
    private int prefabNum = 0;      // 生成物件數量
    private bool isSpawn = true;   // 是否生成

    private void FixedUpdate()
    {
        if (isSpawn)
        {
            // 計時(生成間隔時間)
            StartCoroutine("Wait");
            // 生成敵人
            GeneratePrefab();
            isSpawn = false;
        }
    }

    private void GeneratePrefab(){
        // 生成隨機數量
        prefabNum = Random.Range(0,generateAmount);

        for (int i = 0; i < prefabNum; i++)
        {
            generatePosX = Random.Range(-generateMaxRange, generateMaxRange);
            generatePosY = Random.Range(-generateMaxRange, generateMaxRange);
            Instantiate(spawnPrefab, new Vector3( transform.position.x + generatePosX,
                                                  transform.position.y + generatePosY, 0), Quaternion.identity);
        }
    }

    // 生成間隔時間
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(spawnTime);
        isSpawn = true;
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(generateMaxRange * 2, generateMaxRange * 2, 0));
    }
    */
}
