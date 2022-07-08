using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerScripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float moveForce = 10f;

        [SerializeField]
        private float jumpForce = 1f;

        private float _movementX;

        private Rigidbody2D _myBody;
        private CapsuleCollider2D _playerCollider;
        private Animator _anim;

        private const string WalkAnimation = "Walk";
        private const string EnemyTag = "Enemy";
        private const string Horizontal = "Horizontal";
        private const string Jump = "Jump";
        private const string GameOver = "GameOver";

        [SerializeField]
        private LayerMask groundMask;

        public ParticleSystem deathParticle;
        private static readonly int Walk = Animator.StringToHash(WalkAnimation);

        public bool isFlipped;

        private void Awake()
        {
            _myBody = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
            _playerCollider = gameObject.GetComponent<CapsuleCollider2D>();
        }

        private void Start()
        {
            GameManager.isGameOver = false;
        }

        private void Update()
        {
            if (GameManager.isGameOver) return;
            PlayerMoveKeyboard();
            AnimatePlayer();
        }

        private void FixedUpdate()
        {   
            if (!GameManager.isGameOver)
                PlayerJump();
        }

        private void PlayerMoveKeyboard()
        {
            _movementX = Input.GetAxisRaw(Horizontal);
            transform.position += moveForce * Time.deltaTime * new Vector3(_movementX, 0f, 0f);
        }

        private void AnimatePlayer()
        {
            switch (_movementX)
            {
                case > 0:
                    transform.localScale = new Vector2(1, 1);
                    isFlipped = false;
                    _anim.SetBool(Walk, true);
                    break;
                case < 0:
                    transform.localScale = new Vector2(-1, 1);
                    isFlipped = true;
                    _anim.SetBool(Walk, true);
                    break;
                default:
                {
                    var myTransform = transform;
                    myTransform.localScale = new Vector2(myTransform.localScale.x, 1);
                    _anim.SetBool(Walk, false);
                    break;
                }
            }
        }

        private void PlayerJump()
        {
            if (!Input.GetButton(Jump) || !IsGrounded()) return;
            var jumpVector = Vector2.up * jumpForce;
            jumpVector.x = _myBody.velocity.x;
            _myBody.velocity = jumpVector;
        }

        private bool IsGrounded()
        {
            bool hit = Physics2D.Raycast(
                transform.position,
                Vector2.down,
                _playerCollider.bounds.extents.y + 0.1f,
                groundMask
            );
            return hit;
        }

        private IEnumerator LoadSceneAfterDelay(float delay)
        {
            GameManager.isGameOver = true;

            // mario type death
            _playerCollider.enabled = false;
            _myBody.velocity = Vector2.zero;
            var jumpVector = Vector2.up * jumpForce;
            _myBody.gravityScale = 1.5f;
            _myBody.AddForce(jumpVector, ForceMode2D.Impulse);
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(GameOver);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag(EnemyTag)) return;
            StartCoroutine(LoadSceneAfterDelay(1.5f));
            Destroy();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag(EnemyTag)) return;
            StartCoroutine(LoadSceneAfterDelay(1.5f));
            Destroy();
        }

        private void Destroy()
        {
            var impactPS = Instantiate(deathParticle, transform.position,
                Quaternion.identity);
            impactPS.Play();
        }

    }
}
