using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private CapsuleCollider2D capsuleCollider;
    public bool isDead = false;
    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed * Time.deltaTime; ;
    }
    public void Die()
    {
        isDead = true;
        Destroy(gameObject, 1);
        speed = 0f;
        capsuleCollider.size = new Vector2(0.001f, 0.001f);
        transform.localScale = new Vector2(transform.localScale.x, 1f);
        rb.gravityScale = 100f;
    }
}
