using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float bulletSpeed = 5f;  // �l�u���ʳt��
    public float bulletPower = 5;  // �l�u�¤O

    public Rigidbody2D rb { get; private set; } // ���� rb  
    // =============================================================================
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �l�u����
        bulletPower *= GameManager.playerPowerMultiply;
        bulletSpeed *= GameManager.bulletSpeedMultiply;
        Shoot();
    }

    private void Shoot()
    {
        // �e�i !
        rb.AddForce(GameManager.playerDirection * bulletSpeed );
    }

}
