using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHp = 10;                        // �ĤH��q
    public float enemyPower = 2;                     // �ĤH�����O
    public float score = 1;                           // �ĤH���Ѥ���
    public float moveSpeed = 10f;                   // ���ʳt��
    public Animator enemyAnimator;                  // �ʵe����
    public GameObject player { get; private set; }  // Player ����
    public Rigidbody2D rb { get; private set; }     // �ۨ� rb

    private Transform childTransform;

    // --------------------------------------
    private void Start()
    {
        GameManager.enemies.Add(this.gameObject);               // �[�J enemy �C��
        rb = GetComponent<Rigidbody2D>();
        player = GameManager.player;                            // ���o player
    }

    private void FixedUpdate()
    {
        
        Move();
        if(enemyHp <= 0) Dead();
    }

    // --------------------------------------
    private void Move()
    {
        enemyAnimator.SetInteger("EnemyState",1);                               // �]�w�ʵe���A
        Vector2 moveDistance = (player.transform.position - transform.position).normalized * moveSpeed * Time.fixedDeltaTime;
        Vector2 pos = new Vector2 (rb.position.x, rb.position.y);
        rb.MovePosition(pos + moveDistance);

        // ���a�b�k�� && enemy ���V����
        if( moveDistance.x >= 0 && transform.localScale.x <= 0 ) transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
        // ���a�b���� && enemy ���V�k��
        if (moveDistance.x < 0 && transform.localScale.x > 0) transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
    }

    private void Dead()
    {
        // �[��
        GameManager.score += score;
        GameManager.playerExp += score;

        // �R���l����
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            childTransform = gameObject.transform.GetChild(i);
            GameObject.Destroy(childTransform.gameObject);
        } 
        GameObject.Destroy(gameObject);
    }

}
