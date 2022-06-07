using UnityEngine;

public class PlayerColision : MonoBehaviour
{

    // ����ʵe
    public Animator playerAnimator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Enemy")
        {
            // ������q
            GameManager.playerHp -= collision.gameObject.GetComponent<Enemy>().enemyPower;
            playerAnimator.SetTrigger("hitted");
        }

        if (collision.gameObject.tag == "Wall")
        {
            GameManager.playerDirection = Vector2.zero;
        }
    }

}
