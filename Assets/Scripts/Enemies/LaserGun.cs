using System.Collections;
using UnityEngine;


public class LaserGun : MonoBehaviour
{
    [SerializeField] private GameObject bigBlast,  smallStartBlast;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float timeToBigFire;
    [SerializeField] private float timeToEnd;
    [SerializeField] private float coolDown = 5f;
    private float timeToFire = 1f;


    private void FixedUpdate()
    {
        if (timeToFire < Time.time)
        {
            smallStartBlast.SetActive(true);
            StartCoroutine(Blast());
            timeToFire = Time.time + coolDown;
        }
    }
    private IEnumerator Blast()
    {
        yield return new WaitForSeconds(timeToBigFire);
        bigBlast.SetActive(true);
        yield return new WaitForSeconds(timeToEnd);
        smallStartBlast.SetActive(false);
        bigBlast.SetActive(false);
    }
}
