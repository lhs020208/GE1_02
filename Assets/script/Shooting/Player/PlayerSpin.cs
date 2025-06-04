using UnityEngine;

public class PlayerSpin : MonoBehaviour
{
    PlayerStatusManager Status;
    private Rigidbody rb;
    public float turnSpeed = 100.0f;

    private bool blockAirRotateW = false;
    private bool blockAirRotateS = false;
    private bool wasGroundedLastFrame = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Status = GetComponent<PlayerStatusManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Status.PushS)
        {
            if (Status.PushA)
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
            if (Status.PushD)
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        else
        {
            if (Status.PushA)
                transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
            if (Status.PushD)
                transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
        if (Status.PushQ)
            transform.Rotate(0, 0, turnSpeed * Time.deltaTime * 3);
        if (Status.PushE)
            transform.Rotate(0, 0, -turnSpeed * Time.deltaTime * 3);

        if (!Status.IsContact && wasGroundedLastFrame)
        {
            blockAirRotateW = Status.PushW;
            blockAirRotateS = Status.PushS;
        }
        if (!Status.PushW && !Status.PushS)
        {
            blockAirRotateW = false;
            blockAirRotateS = false;
        }

        bool canRotateW = !Status.IsContact && Status.PushW && !blockAirRotateW;
        bool canRotateS = !Status.IsContact && Status.PushS && !blockAirRotateS;

        if (canRotateW)
        {
            transform.Rotate(turnSpeed * Time.deltaTime * 3, 0, 0);
        }
        if (canRotateS)
        {
            transform.Rotate(-turnSpeed * Time.deltaTime * 3, 0, 0);
        }

        wasGroundedLastFrame = Status.IsContact;
        float dampingRate = 5f;
        rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, Time.deltaTime * dampingRate);

    }
}
