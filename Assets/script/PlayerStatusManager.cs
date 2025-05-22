using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    void OnCollisionStay(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                IsGrounded = true;
                return;
            }
        }
        IsGrounded = false;
    }

    void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
}
