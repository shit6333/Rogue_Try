using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Transform player { get; private set; }
    public bool isFlipped = false;
    void Start()
    {
        player = GameManager.player.transform;
    }

    // Collision °»´ú
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GetComponent<BossHealth>().TakeDamage(collision.gameObject.GetComponent<Bullet>().bulletPower);
            GameObject.Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Sword")
        {
            GetComponent<BossHealth>().TakeDamage(GameManager.swordPower);
        }

        Debug.Log(GetComponent<BossHealth>().health);
    }


    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else if (transform.position.x <= player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
    }
}
