using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;
    private const string EnemyAudioSfxTag = "EnemyAudioSource";

    [SerializeField]
    private AudioClip enemyDeathSfx;
    [SerializeField]
    private AudioSource enemyKillAudioSource;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        enemyKillAudioSource = GameObject.FindWithTag(EnemyAudioSfxTag).GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
    }

    public void PlayDeathAudio()
    {
        enemyKillAudioSource.Play();
    }
}
