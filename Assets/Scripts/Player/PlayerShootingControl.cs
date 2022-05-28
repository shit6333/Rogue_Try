using UnityEngine;

public class PlayerShootingControl : MonoBehaviour
{
    public GameObject bulletPrefab;

    // private float passTime = 0;

    private void Start()
    {
        InvokeRepeating(nameof(GenerateBullet), 0.5f, GameManager.playerShootTime);
    }

    private void GenerateBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
