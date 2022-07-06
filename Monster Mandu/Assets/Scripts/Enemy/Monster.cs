using UnityEngine;

namespace Enemy
{
    public class Monster : MonoBehaviour
    {
        [HideInInspector]
        public float speed;

        private Rigidbody2D _myBody;
        private const string EnemyAudioSfxTag = "EnemyAudioSource";

        [SerializeField]
        private AudioSource enemyKillAudioSource;

        private void Awake()
        {
            _myBody = GetComponent<Rigidbody2D>();
            enemyKillAudioSource = GameObject.FindWithTag(EnemyAudioSfxTag).GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            _myBody.velocity = new Vector2(speed, _myBody.velocity.y);
        }

        public void PlayDeathAudio()
        {
            enemyKillAudioSource.Play();
        }
    }
}
