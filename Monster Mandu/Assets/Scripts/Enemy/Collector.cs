using UnityEngine;

namespace Enemy
{
    public class Collector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }

            if (!collision.CompareTag("Player")) return;
            collision.gameObject.transform.position = collision.gameObject.transform.position.x < 0 ? new Vector2(60f,-2f) : new Vector2(-60f,-2f);
        }
    }
}