using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 1f;

    private float movementX;

    private bool freeze = false;

    private Rigidbody2D myBody;
    private CapsuleCollider2D playerCollider;
    private Animator anim;

    private readonly string WALK_ANIMATION = "Walk";

    private readonly string ENEMY_TAG = "Enemy";

    [SerializeField]
    LayerMask groundMask;

    public ParticleSystem deathParticle;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (!freeze) {
            PlayerMoveKeyboard();
            AnimatePlayer();
        }
    }

    private void FixedUpdate()
    {   
        if (!freeze)
            PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += moveForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            transform.localScale = new Vector2(1, 1);
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (movementX < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            var myTransform = transform;
            myTransform.localScale = new Vector2(myTransform.localScale.x, 1);
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    
    void PlayerJump()
    {
        if (Input.GetButton("Jump") && IsGrounded())
        {
            Vector2 jumpVector = Vector2.up * jumpForce;
            jumpVector.x = myBody.velocity.x;
            myBody.velocity = jumpVector;
        }
    }

    private bool IsGrounded()
    {
        bool hit = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            playerCollider.bounds.extents.y + 0.1f,
            groundMask
        );
        return hit;
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {   
        freeze = true;

        // mario type death
        playerCollider.enabled = false;
        myBody.velocity = Vector2.zero;
        Vector2 jumpVector = Vector2.up * jumpForce;
        myBody.gravityScale = 1.5f;
        myBody.AddForce(jumpVector, ForceMode2D.Impulse);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            GameManager.gameOver = true;
            StartCoroutine(LoadSceneAfterDelay(1.5f));
            Destroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            GameManager.gameOver = true;
            StartCoroutine(LoadSceneAfterDelay(1.5f));
            Destroy();
        }
    }

    public void Destroy()
    {
        ParticleSystem impactPS = Instantiate(deathParticle, transform.position,
            Quaternion.identity);
        impactPS.Play();
    }

}
