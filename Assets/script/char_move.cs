using UnityEngine;

public class char_move : MonoBehaviour
{
    public float accel = 5.0f;
    public float turnSpeed = 100.0f;
    public float maxForwardSpeed = 10.0f;
    public float maxBackwardSpeed = 5.0f;

    public float mouseAccel = 10.0f;              // ��Ŭ���� ����
    public float mouseMaxForwardSpeed = 20.0f;   // ��Ŭ���� �ְ�ӵ�

    int moveDir = 0;
    bool mouseMoving = false;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody�� �����ϴ�");
        }
    }

    void Update()
    {
        // ��Ŭ�� ����
        if (Input.GetMouseButtonDown(0))
        {
            mouseMoving = true;
            moveDir = 1;
        }

        // ��Ŭ�� �ߴ�
        if (Input.GetMouseButtonUp(0))
        {
            mouseMoving = false;
            moveDir = 0;
        }

        // ��Ŭ�� ���� ���� W/S ����
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
            // ��Ŭ�� �� W/S �Է� ���� + ������ W/S ����
            if ((Input.GetKeyUp(KeyCode.W) && moveDir == 1) ||
                (Input.GetKeyUp(KeyCode.S) && moveDir == -1))
            {
                moveDir = 1; // ��Ŭ���� �켱�̹Ƿ� ����
            }
        }

        // ȸ��
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
