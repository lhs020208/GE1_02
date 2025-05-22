using UnityEngine;

public class char_move : MonoBehaviour
{
    public float accel = 5.0f;
    public float turnSpeed = 100.0f;
    public float maxForwardSpeed = 10.0f;
    public float maxBackwardSpeed = 5.0f;

    public float mouseAccel = 10.0f;              // 좌클릭용 가속
    public float mouseMaxForwardSpeed = 20.0f;   // 좌클릭용 최고속도

    int moveDir = 0;
    bool mouseMoving = false;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody가 없습니다");
        }
    }

    void Update()
    {
        // 좌클릭 시작
        if (Input.GetMouseButtonDown(0))
        {
            mouseMoving = true;
            moveDir = 1;
        }

        // 좌클릭 중단
        if (Input.GetMouseButtonUp(0))
        {
            mouseMoving = false;
            moveDir = 0;
        }

        // 좌클릭 중일 때는 W/S 무시
        if (!mouseMoving)
        {
            if (Input.GetKeyDown(KeyCode.W) && moveDir == 0)
                moveDir = 1;
            if (Input.GetKeyDown(KeyCode.S) && moveDir == 0)
                moveDir = -1;

            if (Input.GetKeyUp(KeyCode.W) && moveDir == 1)
                moveDir = 0;
            if (Input.GetKeyUp(KeyCode.S) && moveDir == -1)
                moveDir = 0;
        }
        else
        {
            // 좌클릭 중 W/S 입력 무시 + 강제로 W/S 해제
            if ((Input.GetKeyUp(KeyCode.W) && moveDir == 1) ||
                (Input.GetKeyUp(KeyCode.S) && moveDir == -1))
            {
                moveDir = 1; // 좌클릭이 우선이므로 유지
            }
        }

        // 회전
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }

    void FixedUpdate()
    {
        if (rb != null && moveDir != 0)
        {
            float currentSpeed = Vector3.Dot(rb.linearVelocity, transform.forward);
            float targetAccel = mouseMoving ? mouseAccel : accel;
            float targetMaxSpeed = mouseMoving ? mouseMaxForwardSpeed :
                (moveDir == 1 ? maxForwardSpeed : maxBackwardSpeed);

            if ((moveDir == 1 && currentSpeed < targetMaxSpeed) ||
                (moveDir == -1 && currentSpeed > -targetMaxSpeed))
            {
                rb.AddForce(transform.forward * targetAccel * moveDir, ForceMode.Acceleration);
            }
        }
    }
}
