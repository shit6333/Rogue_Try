using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Enemy enemy { get; private set; }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemy.enemyHp -= collision.gameObject.GetComponent<Bullet>().bulletPower;
            GameObject.Destroy(collision.gameObject);
        }
    }

}
