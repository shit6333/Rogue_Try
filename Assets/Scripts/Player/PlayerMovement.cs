using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }
    public Vector2 direction { get; private set; }

    // ����ʵe
    public Animator playerAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.playerDirection = Vector2.right;
    }

    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            if( transform.localScale.x <= 0 ) transform.localScale = new Vector3(-transform.localScale.x , transform.localScale.y, 0); // �H��½��
            GameManager.playerDirection = Vector2.right;
            Move(GameManager.playerDirection);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (transform.localScale.x >= 0) transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0); // �H��½��
            GameManager.playerDirection = Vector2.left;
            Move(GameManager.playerDirection);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            GameManager.playerDirection = Vector2.up;
            Move(GameManager.playerDirection);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GameManager.playerDirection = Vector2.down;
            Move(GameManager.playerDirection);
        }
        else
        {
            rb.velocity = Vector2.zero;
            playerAnimator.SetInteger("RunState", 0);
        }
            
        if(playerAnimator.GetBool("hit") == true) playerAnimator.SetBool("hit", false);
    }

    private void Move(Vector2 direction)
    {
        if (direction != Vector2.zero)
        { 
            playerAnimator.SetInteger("RunState", 1);                    // ���樫���ʵe
            Vector2 pos = new Vector2(rb.position.x, rb.position.y);
            Vector2 moveDistance = direction * GameManager.moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(pos + moveDistance);
        }
    }
}
