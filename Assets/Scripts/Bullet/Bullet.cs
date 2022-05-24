using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float bulletSpeed = 5f;  // �l�u���ʳt��
    public int bulletPower = 5;  // �l�u�¤O

    public Rigidbody2D rb { get; private set; } // ���� rb  
    // =============================================================================
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // �H���˷ǼĤH
        //target = GameManager.enemies[Random.Range(0, GameManager.enemies.Count)];
        Shoot();
    }

    private void Shoot()
    {
        // �e�i !
        rb.AddForce(GameManager.playerDirection * bulletSpeed );
    }

}
