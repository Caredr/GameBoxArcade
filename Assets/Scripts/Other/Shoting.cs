using UnityEngine;

public class Shoting : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float collDown= 1f;
    [SerializeField] private float timeToCreation = 0f;
    public void Fire()
    {
        if(timeToCreation < Time.time)
        {
            GameObject bullet = ObjectPool.instance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = shootPoint.position;
                bullet.SetActive(true);
            }
            timeToCreation = Time.time + collDown;
        }
        
    }
}
