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
    public bool ClickL = false;

    float verticalInputBoost;
    Vector2 MoveBasedY;
    float verticalInput;

    void Start()
    {
    }

    void Update()
    {
        PushW = MoveBasedY.y > 0;
        PushS = MoveBasedY.y < 0;
        PushA = MoveBasedY.x < 0;
        PushD = MoveBasedY.x > 0;
        PushQ = verticalInput > 0;
        PushE = verticalInput < 0;
    }
    void OnCollisionStay(Collision collision)
    {
        IsGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }

    void OnWASDMove(InputValue value)
    {
        MoveBasedY = value.Get<Vector2>();
    }
    void OnQEMove(InputValue value)
    {
        verticalInput = value.Get<float>();
    }
    void OnBoost(InputValue value)
    {
        verticalInputBoost = value.Get<float>();
        ClickL = verticalInputBoost > 0;
    }

}
