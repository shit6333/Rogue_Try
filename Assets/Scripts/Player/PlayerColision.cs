using UnityEngine;

public class PlayerColision : MonoBehaviour
{
    public int Hp = 10;

    private void Start()
    {
        GameManager.playerMaxHp = Hp;   // �]�w�̰���q
        GameManager.playerHp = Hp;      // �]�w�H����e��q
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            // ������q
            GameManager.playerHp -= collision.gameObject.GetComponent<Enemy>().enemyPower;
        }

        if (collision.gameObject.tag == "Wall")
        {
            GameManager.playerDirection = Vector2.zero;
        }
    }

}
