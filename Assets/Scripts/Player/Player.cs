using UnityEngine;

public class Player : MonoBehaviour
{
    public int Hp = 10;
    public float moveSpeed = 1.0f;
    public float shootTime = 2f;

    public float ALevelExp = 10f;
    public float levelMultiply = 1.2f;

    private void Awake()
    {
        // �򥻼ƭȳ]�w
        GameManager.playerMaxHp = Hp;
        GameManager.playerHp = Hp;
        GameManager.moveSpeed = moveSpeed;
        GameManager.playerShootTime = shootTime;

        // �ɯų]�w
        GameManager.playerALevelExp = ALevelExp;
        GameManager.levelExpMultiply = levelMultiply;

    }
}
