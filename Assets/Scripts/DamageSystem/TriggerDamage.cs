using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    private HealthSystem health;
    [SerializeField] private float enterDamage = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.Instance.healthContainer.ContainsKey(collision.gameObject))
        {
            health = GameManager.Instance.healthContainer[collision.gameObject];
            health.TakeHit(enterDamage);
        }
    }
}
