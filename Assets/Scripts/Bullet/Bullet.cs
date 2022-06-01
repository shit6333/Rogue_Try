using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float bulletSpeed = 5f;  // 子彈移動速度
    public float bulletPower = 5;  // 子彈威力

    public Rigidbody2D rb { get; private set; } // 本身 rb  
    // =============================================================================
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // 子彈物件
        bulletPower *= GameManager.playerPowerMultiply;
        bulletSpeed *= GameManager.bulletSpeedMultiply;
        Shoot();
    }

    private void Shoot()
    {
        // 前進 !
        rb.AddForce(GameManager.playerDirection * bulletSpeed );
    }

}
