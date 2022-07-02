using System;
using UnityEngine;

namespace Shooting
{
    public class Bullet : MonoBehaviour
    {
        private void OnEnable()
        {
            Destroy(gameObject, 3);
        }
    }
}
