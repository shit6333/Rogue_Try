using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_walk : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f; 
    public Transform player { get; private set; }
    private Rigidbody2D rb;
    private Boss boss;

    //  OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameManager.player.transform;
        boss = animator.GetComponent<Boss>();
        rb = animator.GetComponent<Rigidbody2D>();  // 利用此動畫所在的 Animator 物件找尋 Rigidbody2D
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 targetPos = new Vector2( player.position.x, player.position.y );
        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, speed * Time.fixedDeltaTime);   // 向玩家移動向量
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }


}
