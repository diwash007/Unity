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
            Destroy(gameObject, 3);
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag(Enemy)) return;
            
            var particle = Instantiate(hitParticle, transform.position, Quaternion.identity);
            particle.Play();
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        
        
    }
}
