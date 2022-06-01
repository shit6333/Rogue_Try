using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public List<GameObject> enemies = new List<GameObject>();
    static public GameObject player;

    // Plyaer 基本數值
    static public float playerMaxHp = 0;          // 最大 Hp
    static public float playerHp = 0;             // 玩家 Hp
    static public float playerShootTime = 2f;   // 玩家射擊速度 
    static public float moveSpeed = 5f;         // 玩家移動速度
    static public bool playCantMove = false;    // 玩家可否移動
    static public Vector2 playerDirection;      // 玩家移動方向
    static public float playerPowerMultiply = 1f; // 玩家攻擊力倍率

    // 等級設定
    static public int playerLevel = 0;            // 玩家等級
    static public float playerALevelExp = 0;      // 玩家升級所需 Exp
    static public float levelExpMultiply = 1.2f;  // 玩家升級所需 exp 加成
    static public float playerExp = 0;            // 玩家 Exp

    // 武器設定 
    static public float swordRotateSpeed = 1f;
    static public float swordLevel = 0;
    static public float swordPower = 1f;
    static public float bulletSpeedMultiply = 1f;   // 子彈飛行速度加乘

    // 遊玩設定
    static public float score = 0;                // 分數

    // =============================================================================================================

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");    // 取得玩家物件
    }

    private void Update()
    {
        // 升級
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
        playerLevel++;      // 升等
        playerALevelExp *= levelExpMultiply;   // 升級所需exp加成
        playerExp = 0;      // 經驗歸 0
    }
}
