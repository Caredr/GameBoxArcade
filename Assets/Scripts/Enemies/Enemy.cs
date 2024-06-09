using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthSystem))]
public class Enemy : MonoBehaviour
{
    public static UnityAction<Enemy, int> OnEnemyDestroy;

    [SerializeField][Min(0)] private int murderReward = 100; 

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] float left, right;
    [SerializeField] private Vector3 direction;

    private HealthSystem health;

    private void Awake()
    {
        health= GetComponent<HealthSystem>();
        health.OnBroken.AddListener(OnDestroy);
    }


    void FixedUpdate()
    {
        MoveAndBounds(); 
    }

    private void OnDestroy()
    {
        if (health.CurrentHealth > 0)
        {
            murderReward = 0;
        }

        OnEnemyDestroy?.Invoke(this, murderReward);

        if (gameObject != null)
        {
           Destroy(gameObject);
        }
    }


    private void MoveAndBounds()
    {
        Vector3 temp = transform.position;
        transform.position = transform.position + moveSpeed * Time.fixedDeltaTime * direction.normalized;

        if (temp.x >= right && direction.x > 0)
        {
            direction.x *= -1;
        }

        else if (temp.x <= left && direction.x < 0)
        {
            direction.x *= -1;
        }
    }


}
