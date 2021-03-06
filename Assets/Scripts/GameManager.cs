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
    static public float bulletPower = 5f;
    static public float bulletSpeedMultiply = 1f;   // 子彈飛行速度加乘

    // 怪物控管
    public int maxEnemyQuanity = 10;                // 最高 Enemy 數量
    public int hasBossMaxEnemyQuanity = 10;         // 如場上有 Boss 時的 enemy 數量
    static public List<GameObject> allEnemysList;    // Enemy List : 用來做數量控管
    static public bool canSpawn = true;

    // 遊玩設定
    static public float score = 0;                // 分數
    public GameObject boss;
    private bool hasBoss = false;
    // =============================================================================================================

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");    // 取得玩家物件
        allEnemysList = new List<GameObject>();
    }

    private void Update()
    {
        // 升級
        if(playerExp >= playerALevelExp) LevelUp();
        // 怪物數量控管
        if(allEnemysList.Count > maxEnemyQuanity) // 超過一定數量
        {
            canSpawn = false;        // 停止生成 enemy
        }
        else
        {
            if(!canSpawn) canSpawn = true;
        }

        // 生成 Boss
        if(playerLevel > 2 && !hasBoss)
        {
            CreatBoss();
            maxEnemyQuanity = hasBossMaxEnemyQuanity;   // 控管場上怪物數量
            hasBoss = true; // 已有 Boss 
        }
    }

    void LevelUp()
    {
        playerLevel++;      // 升等
        playerALevelExp *= levelExpMultiply;   // 升級所需exp加成
        playerExp = 0;      // 經驗歸 0
    }

    // 召喚 Boss
    void CreatBoss()
    {
        Instantiate(boss, new Vector3(0 ,0, 0), Quaternion.identity );
    }
}
