using System;
using UnityEngine;

namespace Enemy
{
    public class Collector : MonoBehaviour
    {
        public bool isInPortal;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }
        }

        
    }
}