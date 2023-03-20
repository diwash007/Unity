using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private CapsuleCollider2D playerCollider;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float jumpForce = 10;
    public float direction;
    public float hp = 100;
    private Vector2 startLocalScale;

    [SerializeField]
    private Transform groundCheckerTransform;
    [SerializeField]
    private float groundDistance;
    [SerializeField]
    private LayerMask groundLayerMask;
    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private Animator animator;
    private bool isDead = false;

    private void Start()
    {
        startLocalScale = transform.localScale;
    }

    private void Update()
    {
        isGrounded = IsGrounded();
        if (!isDead)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.localScale = startLocalScale;
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.localScale = new Vector3(-startLocalScale.x, transform.localScale.y);
                direction = -1;
            }
            else
            {
                direction = 0;
            }
            // Jumping 
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector3(0, jumpForce, 0));
            }
        }


        animator.SetFloat("speed", Mathf.Abs(direction));
        animator.SetBool("jump", !isGrounded && rb.velocity.y > 0);
        animator.SetBool("fall", !isGrounded && rb.velocity.y < -0.2);
    }
    private void FixedUpdate()
    {
        if (!isDead)
            rb.velocity = new Vector2(speed * direction * Time.deltaTime, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(groundCheckerTransform.position, Vector3.down, groundDistance, groundLayerMask);
        return hitInfo.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<Enemy>().isDead == true)
                return;
            isDead = true;
            hp = 0f;
            Destroy(gameObject, 3);
            playerCollider.enabled = false;
            rb.velocity = Vector2.zero;
            var jumpVector = Vector2.up * jumpForce;
            rb.gravityScale = 2f;
            rb.AddForce(jumpVector * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    // private void OnDrawGizmos() {
    //     Debug.DrawRay(groundCheckerTransform.position, Vector3.down * groundDistance);
    // }

}
