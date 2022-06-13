using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHp = 10;                        // 敵人血量
    public float enemyPower = 2;                     // 敵人攻擊力
    public float score = 1;                           // 敵人提供分數
    public float moveSpeed = 10f;                   // 移動速度
    public Animator enemyAnimator;                  // 動畫控制
    public GameObject player { get; private set; }  // Player 物件
    public Rigidbody2D rb { get; private set; }     // 自身 rb

    private Transform childTransform;

    // --------------------------------------
    private void Start()
    {
        GameManager.enemies.Add(this.gameObject);               // 加入 enemy 列表
        rb = GetComponent<Rigidbody2D>();
        player = GameManager.player;                            // 取得 player
    }

    private void FixedUpdate()
    {
        
        Move();
        if(enemyHp <= 0) Dead();
        if(enemyAnimator.GetBool("hit") == true) enemyAnimator.SetBool("hit",false);
    }

    // --------------------------------------
    private void Move()
    {
        enemyAnimator.SetInteger("EnemyState",1);                               // 設定動畫狀態
        Vector2 moveDistance = (player.transform.position - transform.position).normalized * moveSpeed * Time.fixedDeltaTime;
        Vector2 pos = new Vector2 (rb.position.x, rb.position.y);
        rb.MovePosition(pos + moveDistance);

        // 玩家在右邊 && enemy 面向左邊
        if( moveDistance.x >= 0 && transform.localScale.x <= 0 ) transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
        // 玩家在左邊 && enemy 面向右邊
        if (moveDistance.x < 0 && transform.localScale.x > 0) transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
    }

    private void Dead()
    {
        // 加分
        GameManager.score += score;
        GameManager.playerExp += score;

        // 從 Enemy List 中移除掉第一個元素
        GameManager.allEnemysList.RemoveAt(0);

        // 刪除子物件
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            childTransform = gameObject.transform.GetChild(i);
            GameObject.Destroy(childTransform.gameObject);
        } 
        GameObject.Destroy(gameObject);
    }

}
