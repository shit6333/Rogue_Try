using UnityEngine;

public class PlayerColision : MonoBehaviour
{

    // 控制動畫
    public Animator playerAnimator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            // 扣除血量
            GameManager.playerHp -= collision.gameObject.GetComponent<Enemy>().enemyPower;
            playerAnimator.SetBool("hit",true);
        }

        if (collision.gameObject.tag == "Wall")
        {
            GameManager.playerDirection = Vector2.zero;
        }
    }

}
