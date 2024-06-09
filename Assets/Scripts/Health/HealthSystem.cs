using UnityEngine;
using UnityEngine.Events;
public class HealthSystem : MonoBehaviour
{
    public UnityEvent OnBroken;

    [SerializeField] private float health;
    [SerializeField] private HealthBar healthBar;
    public float CurrentHealth
    {
        get;
        private set;
    }


    private void Awake()
    {
        CurrentHealth = health;
    }

    private void Start()
    {
        GameManager.Instance.healthContainer.Add(gameObject, this);
        HealthBarChceckAndSet();
    }

    public void TakeHit(float damage)
    {
        CurrentHealth -= damage;
        HealthBarChceckAndSet();
        if (CurrentHealth <= 0)
        { 
            OnBroken.Invoke();   
        }
    }

    public void HealHealth(float bonushealth)
    {
        CurrentHealth += bonushealth;
        HealthBarChceckAndSet();
        if (CurrentHealth > 100)
        {
            CurrentHealth = 100;
        }
    }

    private void HealthBarChceckAndSet()
    {
        if (healthBar != null)
        {
            healthBar.SetHeath(CurrentHealth);
        }
    }
}
