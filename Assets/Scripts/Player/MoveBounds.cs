
using UnityEngine;

public class MoveBounds : MonoBehaviour
{
    [SerializeField] float left, right;
    void Update()
    {
        Vector3 temp = transform.position;
        if (temp.x > right)
            temp.x = right;
        if (temp.x < left)
            temp.x = left;
        transform.position = temp;
    }
}
