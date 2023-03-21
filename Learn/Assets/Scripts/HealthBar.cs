using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private const float MAX_HEALTH = 100f;
    [SerializeField]
    private Image health;
    [SerializeField]
    PlayerController player;
    // Update is called once per frame
    void Update()
    {
        health.fillAmount = Mathf.Lerp(health.fillAmount, player.hp / MAX_HEALTH, 0.1f);
    }
}
