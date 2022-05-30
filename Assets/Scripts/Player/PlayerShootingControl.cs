using UnityEngine;
using System.Collections;

public class PlayerShootingControl : MonoBehaviour
{
    public GameObject bulletPrefab;
    private bool shoot = true;

    // private float passTime = 0;

    private void Start()
    {
        shoot = true;
    }

    private void FixedUpdate()
    {
        if(shoot)
        {
            // 計時(發射間隔)
            StartCoroutine("Wait");
            // 發射
            GenerateBullet();
            shoot = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(GameManager.playerShootTime);
        shoot = true;
    }

    private void GenerateBullet()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
