using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.transform.position.x < 0)
                collision.gameObject.transform.position = new Vector2(60f,-2f);
            else 
                collision.gameObject.transform.position = new Vector2(-60f,-2f);

        }


    }
}