using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public List<GameObject> enemies = new List<GameObject>();
    static public GameObject player;
    static public int playerHp = 0;             // ���a Hp
    static public bool playCantMove = false;    // ���a�i�_����
    static public Vector2 playerDirection;      // ���a���ʤ�V

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");    // ���o���a����
    }

    private void Update()
    {
        Debug.Log("Hp: " + playerHp);
    }

}
