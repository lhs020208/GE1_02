using UnityEngine;

public class PlayerMoveR : MonoBehaviour
{
    RacingPlayerStatusManager Status;
    public float accel = 10.0f;
    public float maxForwardSpeed = 10.0f;
    public float maxBackwardSpeed = 5.0f;

    public float SurfaceTension = 100.0f;
    public float mouseAccel = 20.0f;              // 좌클릭용 가속
    public float mouseMaxForwardSpeed = 40.0f;   // 좌클릭용 최고속도

    int moveDir = 0;
    bool mouseMoving = false;

    Rigidbody rb;

    void Start()
    {
        Status = GetComponent<RacingPlayerStatusManager>();
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody가 없습니다");
        }
    }

    void Update()
    {
        if (Status.ClickL)
        {
            mouseMoving = true;
            moveDir = 1;
        }

        if (!Status.ClickL)
        {
            mouseMoving = false;
            moveDir = 0;
        }

        if (!mouseMoving)
        {
            if (Status.PushW && moveDir == 0)
                moveDir = 1;
            if (Status.PushS && moveDir == 0)
                moveDir = -1;

            if (!Status.PushW && moveDir == 1)
                moveDir = 0;
            if (!Status.PushS && moveDir == -1)
                moveDir = 0;
        }
        else
        {
            if ((!Status.PushW && moveDir == 1) ||
                (!Status.PushS && moveDir == -1))
            {
                moveDir = 1;
            }
        }
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            if (Status.IsGrounded)
            {
                rb.AddForce(-transform.up * SurfaceTension, ForceMode.Force);
                rb.AddForce(Vector3.up * 9.81f, ForceMode.Force);

                if (moveDir != 0)
                {
                    float currentSpeed = Vector3.Dot(rb.linearVelocity, transform.forward);

                    float targetAccel;
                    float targetMaxSpeed;

                    if (mouseMoving)
                    {
                        targetAccel = mouseAccel;
                        targetMaxSpeed = mouseMaxForwardSpeed;
                    }
                    else
                    {
                        targetAccel = accel;

                        if (moveDir == 1)
                        {
                            targetMaxSpeed = maxForwardSpeed;
                        }
                        else
                        {
                            targetMaxSpeed = maxBackwardSpeed;
                        }
                    }

                    bool underMaxSpeed = false;

                    if (moveDir == 1 && currentSpeed < targetMaxSpeed)
                    {
                        underMaxSpeed = true;
                    }
                    else if (moveDir == -1 && currentSpeed > -targetMaxSpeed)
                    {
                        underMaxSpeed = true;
                    }

                    if (underMaxSpeed)
                    {
                        if (mouseMoving || Status.IsGrounded)
                        {
                            rb.AddForce(transform.forward * targetAccel * moveDir, ForceMode.Acceleration);
                        }
                    }
                }
            }
        }
    }
}
