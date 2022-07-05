using UnityEngine;

namespace Shooting
{
    public class Bullet : MonoBehaviour
    {
        private const string Enemy = "Enemy";

        [SerializeField]
        private ParticleSystem hitParticle;
    
        private void OnEnable()
        {
            Destroy(gameObject, 0.3f);
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag(Enemy)) return;
            
            var particle = Instantiate(hitParticle, transform.position, Quaternion.identity);
            particle.Play();
            GameManager.scoreValue += 5;
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        
        
    }
}
