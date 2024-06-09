
using UnityEngine;

public class PlayerInput : MonoBehaviour
{ 
    private float horizontal;
    private PlayerMovement plMove;
    private Shoting shooting;

    private void Start()
    {
        plMove= GetComponent<PlayerMovement>();
        shooting = GetComponent<Shoting>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Input.GetButton("Fire1"))
        {
            shooting.Fire();
        }
    }

    private void FixedUpdate()
    {
        plMove.PlayerMove(horizontal);
    }
}
