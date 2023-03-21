using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private const float MAX_HEALTH = 100f;
    [SerializeField]
    private Image health;
    [SerializeField]
    PlayerController player;

    void Update()
    {
        health.fillAmount = Mathf.MoveTowards(health.fillAmount, player.hp / MAX_HEALTH, 2f * Time.deltaTime);
    }
}
