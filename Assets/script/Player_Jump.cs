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
                Vector3 PushV = Vector3.zero;

                Vector3 forward = transform.forward;
                Vector3 right = transform.right;

                if (Status.PushW && Status.PushD)
                    PushV = (forward + right).normalized * 0.5f;
                else if (Status.PushW && Status.PushA)
                    PushV = (forward - right).normalized * 0.5f;
                else if (Status.PushS && Status.PushD)
                    PushV = (-forward + right).normalized * 0.5f;
                else if (Status.PushS && Status.PushA)
                    PushV = (-forward - right).normalized * 0.5f;
                else if (Status.PushW)
                    PushV = forward * 0.5f;
                else if (Status.PushS)
                    PushV = -forward * 0.5f;
                else if (Status.PushA)
                    PushV = -right * 0.5f;
                else if (Status.PushD)
                    PushV = right * 0.5f;
                else
                    PushV = Vector3.up;

                GetComponent<Rigidbody>().AddForce(PushV * JumpForce * 2f, ForceMode.Impulse);
            }
            IsJumping = false;
        }
    }

}
