using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    public bool IsGrounded = false;
    public bool PushW = false;
    public bool PushS = false;
    public bool PushA = false;
    public bool PushD = false;
    public bool PushQ = false;
    public bool PushE = false;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            PushW = true;
        if (Input.GetKeyUp(KeyCode.W))
            PushW = false ;
        if (Input.GetKeyDown(KeyCode.S))
            PushS = true;
        if (Input.GetKeyUp(KeyCode.S))
            PushS = false;
        if (Input.GetKeyDown(KeyCode.A))
            PushA = true;
        if (Input.GetKeyUp(KeyCode.A))
            PushA = false;
        if (Input.GetKeyDown(KeyCode.D))
            PushD = true;
        if (Input.GetKeyUp(KeyCode.D))
            PushD = false;
        if (Input.GetKeyDown(KeyCode.Q))
            PushQ = true;
        if (Input.GetKeyUp(KeyCode.Q))
            PushQ = false;
        if (Input.GetKeyDown(KeyCode.E))
            PushE = true;
        if (Input.GetKeyUp(KeyCode.E))
            PushE = false;
    }
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
