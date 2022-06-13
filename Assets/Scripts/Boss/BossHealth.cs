using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float maxhealth = 50;
    public float health { get; private set; }
    public bool isInvulnerable = false; // 無敵時間
    private void Start()
    {
        health = maxhealth;
    }


    public void TakeDamage( float damage)
    {
        if(isInvulnerable) 
            return;

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        else if (health <= maxhealth/2)  // 進入瘋狂模式
        {
            if(!GetComponent<Animator>().GetBool("isAngry"))
                GetComponent<Animator>().SetBool("isAngry", true);
        }

    }

    public void Die()
    {
        GameObject.Destroy (gameObject);
    }
}
