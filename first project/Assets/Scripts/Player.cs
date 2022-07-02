using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 1f;

    private float movementX;

    private SpriteRenderer sr;

    private Rigidbody2D myBody;
    private CapsuleCollider2D playerCollider;
    private Animator anim;

    private readonly string WALK_ANIMATION = "Walk";

    private bool canJump;
    private readonly string ENEMY_TAG = "Enemy";

    [SerializeField]
    LayerMask groundMask;

    public ParticleSystem deathParticle;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
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
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else anim.SetBool(WALK_ANIMATION, false);
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
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            GameManager.gameOver = true;
            Destroy();
            StartCoroutine(LoadSceneAfterDelay(3.0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            GameManager.gameOver = true;
            Destroy();
            StartCoroutine(LoadSceneAfterDelay(3.0f));
        }
    }

    public void Destroy()
    {
        ParticleSystem impactPS = Instantiate(deathParticle, transform.position,
            Quaternion.identity) as ParticleSystem;
        impactPS.Play();
        Debug.Log("hmm");
        Destroy(gameObject);
    }

}
