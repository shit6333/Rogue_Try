using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public float power = 8;
    public float attackRange = 3f;
    public Vector3 attackOffset;
    public LayerMask attackMask;

    private Vector3 attackPos ;

    public void Attack()
    {
        attackPos = transform.position;
        attackPos += transform.right * attackOffset.x;
        attackPos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(attackPos, attackRange, attackMask);
        if(colInfo != null && colInfo.tag == "Player")
        {
            GameManager.playerHp -= power;
        }
    }

    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos, attackRange); 
        
    }
}
