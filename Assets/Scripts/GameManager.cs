using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public List<GameObject> enemies = new List<GameObject>();
    static public GameObject player;

    // Plyaer �򥻼ƭ�
    static public float playerMaxHp = 0;          // �̤j Hp
    static public float playerHp = 0;             // ���a Hp
    static public float playerShootTime = 2f;   // ���a�g���t�� 
    static public float moveSpeed = 5f;         // ���a���ʳt��
    static public bool playCantMove = false;    // ���a�i�_����
    static public Vector2 playerDirection;      // ���a���ʤ�V
    static public float playerPowerMultiply = 1f; // ���a�����O���v

    // ���ų]�w
    static public int playerLevel = 0;            // ���a����
    static public float playerALevelExp = 0;      // ���a�ɯũһ� Exp
    static public float levelExpMultiply = 1.2f;  // ���a�ɯũһ� exp �[��
    static public float playerExp = 0;            // ���a Exp

    // �Z���]�w 
    static public float swordRotateSpeed = 1f;
    static public float swordLevel = 0;
    static public float swordPower = 1f;
    static public float bulletPower = 5f;
    static public float bulletSpeedMultiply = 1f;   // �l�u����t�ץ[��

    // �Ǫ�����
    public int maxEnemyQuanity = 10;                // �̰� Enemy �ƶq
    public int hasBossMaxEnemyQuanity = 10;         // �p���W�� Boss �ɪ� enemy �ƶq
    static public List<GameObject> allEnemysList;    // Enemy List : �ΨӰ��ƶq����
    static public bool canSpawn = true;

    // �C���]�w
    static public float score = 0;                // ����
    public GameObject boss;
    private bool hasBoss = false;
    // =============================================================================================================

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");    // ���o���a����
        allEnemysList = new List<GameObject>();
    }

    private void Update()
    {
        // �ɯ�
        if(playerExp >= playerALevelExp) LevelUp();
        // �Ǫ��ƶq����
        if(allEnemysList.Count > maxEnemyQuanity) // �W�L�@�w�ƶq
        {
            canSpawn = false;        // ����ͦ� enemy
        }
        else
        {
            if(!canSpawn) canSpawn = true;
        }

        // �ͦ� Boss
        if(playerLevel > 2 && !hasBoss)
        {
            CreatBoss();
            maxEnemyQuanity = hasBossMaxEnemyQuanity;   // ���޳��W�Ǫ��ƶq
            hasBoss = true; // �w�� Boss 
        }
    }

    void LevelUp()
    {
        playerLevel++;      // �ɵ�
        playerALevelExp *= levelExpMultiply;   // �ɯũһ�exp�[��
        playerExp = 0;      // �g���k 0
    }

    // �l�� Boss
    void CreatBoss()
    {
        Instantiate(boss, new Vector3(0 ,0, 0), Quaternion.identity );
    }
}
