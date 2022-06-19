using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Enemy enemy { get; private set; }
    public Animator enemyAnimator;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // 確定本體還存在
            if (this.gameObject != null)
            {
                enemy.enemyHp -= (GameManager.bulletPower * GameManager.playerPowerMultiply);
                if (!enemyAnimator.GetBool("hit"))
                    enemyAnimator.SetBool("hit", true);
                GameObject.Destroy(collision.gameObject);
            }
        }

        if(collision.gameObject.tag == "Sword")
        {
            // 確定本體還存在
            if (this.gameObject != null)
            {
                if (!enemyAnimator.GetBool("hit"))
                    enemyAnimator.SetBool("hit", true);
                enemy.enemyHp -= GameManager.swordPower;
            }

        }
    }

}
