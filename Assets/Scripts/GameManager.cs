using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public List<GameObject> enemies = new List<GameObject>();
    static public GameObject player;
    static public int playerMaxHp = 0;
    static public int playerHp = 0;             // 玩家 Hp
    static public int playerLevel = 0;          // 玩家等級
    static public bool playCantMove = false;    // 玩家可否移動
    static public Vector2 playerDirection;      // 玩家移動方向

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");    // 取得玩家物件
    }

    private void Update()
    {
        Debug.Log("Hp: " + playerHp);
    }

}
