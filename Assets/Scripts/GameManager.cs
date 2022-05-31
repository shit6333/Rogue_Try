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

    // �C���]�w
    static public float score = 0;                // ����

    // =============================================================================================================

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");    // ���o���a����
    }

    private void Update()
    {
        // �ɯ�
        if(playerExp >= playerALevelExp) LevelUp();
        Debug.Log("Max Hp: " + playerMaxHp);
        Debug.Log("Hp: " + playerHp);
        Debug.Log("MoveSpeed: " + moveSpeed);
        // Debug.Log("Score: " + score);
        // Debug.Log("level: " + playerLevel);
        Debug.Log("Shoot Time: " + playerShootTime);
    }

    void LevelUp()
    {
        playerLevel++;      // �ɵ�
        playerALevelExp *= levelExpMultiply;   // �ɯũһ�exp�[��
        playerExp = 0;      // �g���k 0
    }
}
