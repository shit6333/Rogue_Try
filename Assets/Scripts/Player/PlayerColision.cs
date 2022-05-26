using UnityEngine;

public class PlayerColision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            // ¦©°£¦å¶q
            GameManager.playerHp -= collision.gameObject.GetComponent<Enemy>().enemyPower;
        }

        if (collision.gameObject.tag == "Wall")
        {
            GameManager.playerDirection = Vector2.zero;
        }
    }

}
