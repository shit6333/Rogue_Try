using UnityEngine;

public class PlayerShootingControl : MonoBehaviour
{
    public float shootTime = 1f;
    public GameObject bulletPrefab;

    // private float passTime = 0;

    private void Start()
    {
        InvokeRepeating(nameof(GenerateBullet), shootTime, 1);
    }

    private void GenerateBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
