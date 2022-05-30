using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    public float spawnTime = 1f;
    public int generateAmount = 2;   // �ͦ��ƶq range
    public float generateMaxRange = 3f; // �ͦ���m range
    
    private float generatePosX;
    private float generatePosY;
    private int prefabNum = 0;      // �ͦ�����ƶq
    private bool isSpawn = true;   // �O�_�ͦ�

    private void FixedUpdate()
    {
        if (isSpawn)
        {
            // �p��(�ͦ����j�ɶ�)
            StartCoroutine("Wait");
            // �ͦ��ĤH
            GeneratePrefab();
            isSpawn = false;
        }
    }

    private void GeneratePrefab(){
        // �ͦ��H���ƶq
        prefabNum = Random.Range(0,generateAmount);

        for (int i = 0; i < prefabNum; i++)
        {
            generatePosX = Random.Range(-generateMaxRange, generateMaxRange);
            generatePosY = Random.Range(-generateMaxRange, generateMaxRange);
            Instantiate(spawnPrefab, new Vector3( transform.position.x + generatePosX,
                                                  transform.position.y + generatePosY, 0), Quaternion.identity);
        }
    }

    // �ͦ����j�ɶ�
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
