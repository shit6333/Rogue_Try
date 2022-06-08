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
            enemy.enemyHp -= collision.gameObject.GetComponent<Bullet>().bulletPower;
            enemyAnimator.SetBool("hit",true);
            GameObject.Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Sword")
        {
            enemyAnimator.SetBool("hit", true);
            enemy.enemyHp -= GameManager.swordPower;
        }
    }

}
