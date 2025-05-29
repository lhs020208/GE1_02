using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RacingPlayerStatusManager : MonoBehaviour
{
    public bool IsGrounded = false;
    public bool PushW = false;
    public bool PushS = false;
    public bool PushA = false;
    public bool PushD = false;
    public bool PushQ = false;
    public bool PushE = false;
    Vector2 move;

    void Start()
    {
    }

    void Update()
    {
        if (move.y > 0)
            PushW = true;
        else
            PushW = false;
        if(move.y < 0)
            PushS = true;
        else
            PushS = false;
        if (move.x < 0)
            PushA = true;
        else
            PushA = false;
        if (move.x > 0)
            PushD = true;
        else
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
    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
    void OnCollisionStay(Collision collision)
    {
        IsGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
}
