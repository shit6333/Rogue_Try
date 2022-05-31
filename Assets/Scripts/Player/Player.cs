using UnityEngine;

public class Player : MonoBehaviour
{
    public float Hp = 10;
    public float moveSpeed = 1.0f;
    public float shootTime = 2f;

    public float ALevelExp = 10f;
    public float levelMultiply = 1.2f;

    private void Awake()
    {
        // 基本數值設定
        GameManager.playerMaxHp = Hp;
        GameManager.playerHp = Hp;
        GameManager.moveSpeed = moveSpeed;
        GameManager.playerShootTime = shootTime;

        // 升級設定
        GameManager.playerALevelExp = ALevelExp;
        GameManager.levelExpMultiply = levelMultiply;

    }
}
