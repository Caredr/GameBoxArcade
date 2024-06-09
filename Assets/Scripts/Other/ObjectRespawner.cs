using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ObjectRespawner : MonoBehaviour
{
    public static float objectLives = 3;
    [SerializeField] private float startHealth = 100f;
    [SerializeField] private float invinsibleTime = 1.5f;

    [SerializeField] private GameObject objectWithExtraLives;
    [SerializeField] private Collider2D objectCol;
    [SerializeField] private SpriteRenderer objectSR;
    [SerializeField] private Transform spawnPoint;
    
    [SerializeField] private HealthSystem objectHealth;

    [SerializeField] private UnityEvent onDestroy;

    void Awake()
    {
        objectLives = 3;
    }

    private void FixedUpdate()
    {
        if(objectHealth.CurrentHealth <= 0)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        if(objectLives > 0)
        {
           
            objectLives--;
            objectHealth.HealHealth(startHealth);
            objectWithExtraLives.transform.position = spawnPoint.position;
            objectCol.enabled = false;
            objectSR.color = Color.blue;
            StartCoroutine(InvinsibleStart());
        }
        else
        {
            onDestroy.Invoke();
        }
       
    }

    IEnumerator InvinsibleStart()
    {
        yield return new WaitForSeconds(invinsibleTime);
        objectCol.enabled = true;
        objectSR.color = Color.white;
    }

}
