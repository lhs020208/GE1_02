using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    PlayerStatusManager Status;
    bool IsJumping = false;
    public float JumpForce = 5.0f;
    void Start()
    {
        Status = GetComponent<PlayerStatusManager>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            IsJumping = true;
        }

        /*
        if (Input.GetKeyDown(KeyCode.W))
            moveDir = 1;
        if (Input.GetKeyDown(KeyCode.S))
            moveDir = -1;

        if (Input.GetKeyUp(KeyCode.W))
            moveDir = 0;
        if (Input.GetKeyUp(KeyCode.S))
            moveDir = 0;
        */
    }

    void FixedUpdate()
    {
        if (IsJumping)
        {
            if (Status != null && Status.IsGrounded)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
            else
            {

            }
            IsJumping = false;
        }
    }

}
