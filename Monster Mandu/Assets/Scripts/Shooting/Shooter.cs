using System;
using System.Collections;
using UnityEngine;

namespace Shooting
{
    public class Shooter : MonoBehaviour
    {
        private const string Fire1 = "Fire1";

        [SerializeField]
        private Transform bulletSpawner;
        [SerializeField]
        private GameObject bullet;

        [SerializeField]
        private float coolDownTimer = 0.3f;
        [SerializeField]
        private float bulletSpeed = 10f;
        [SerializeField]
        private bool canFire;

        private void Update()
        {
            if(!canFire) return;
            if (Input.GetAxis(Fire1) <= 0) return;
            
            Shoot();
        }

        private void Shoot()
        {
            var spawnedBullet = Instantiate(bullet, bulletSpawner.position, Quaternion.identity);
            spawnedBullet.TryGetComponent<Rigidbody2D>(out var bulletRb);
            var dir = transform.localScale.x;
            bulletRb.velocity = new Vector2( dir * bulletSpeed, 0);
            
            canFire = false;
            StopAllCoroutines();
            StartCoroutine(SetCanFire());
        }

        private IEnumerator SetCanFire()
        {
            yield return new WaitForSeconds(coolDownTimer);
            canFire = true;
        }
        
        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}