using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    public int Hp = 10;

    private void Start()
    {
        GameManager.playerMaxHp = Hp;   // 設定最高血量
        GameManager.playerHp = Hp;      // 設定人物當前血量
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            // 扣除血量
            GameManager.playerHp -= collision.gameObject.GetComponent<Enemy>().enemyPower;
        }

        if (collision.gameObject.tag == "Wall")
        {
            GameManager.playerDirection = Vector2.zero;
        }
    }

}
