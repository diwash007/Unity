using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 5;
    [SerializeField]
    private Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed * Time.deltaTime; ;
    }
}
