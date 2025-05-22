using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    bool IsGrounded = false;
    bool IsJumping = false;
    public float JumpForce = 5.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            IsJumping = true;
        }
    }

    void FixedUpdate()
    {
        if (IsGrounded && IsJumping)
        {
            IsJumping = false;
            GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            IsGrounded = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            IsGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
}
