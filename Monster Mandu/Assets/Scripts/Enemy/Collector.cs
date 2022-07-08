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
        }
    }
}