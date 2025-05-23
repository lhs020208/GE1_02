using Unity.VisualScripting;
using UnityEngine;

public class UFOMoving : MonoBehaviour
{
    Rigidbody rb;
    PlayerStatusManager Status;
    public Transform center; // 회전 중심
    public GameObject Player;

    public float speed = 100f; // 초기 속도
    public float forceMagnitude = 200f; // 중심을 향한 구심력 세기
    public float SencerDistance = 500.0f;

    float DistancePlayerVsMe;
    public bool IsClose;
    bool prevIsClose = false;
    public bool IsCloseChanged { get; private set; }


    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null) print("no Player");

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Status = Player.GetComponent<PlayerStatusManager>();
        Vector3 initialVelocity = transform.forward * speed;

        if (center == null)
        {
            center = ComputeCenterFromVelocity(transform.position, initialVelocity, forceMagnitude, rb.mass);
        }
        IsCloseChanged = false;
        prevIsClose = IsClose;

        Vector3 tangent = Vector3.Cross(Vector3.up, (transform.position - center.position).normalized);
        rb.linearVelocity = tangent * speed;
    }
    void Update()
    {
    }
    void FixedUpdate()
    {
        DistancePlayerVsMe = Vector3.Distance(transform.position, Player.transform.position);
        IsClose = DistancePlayerVsMe < SencerDistance;
        IsCloseChanged = (IsClose != prevIsClose);

        if (IsCloseChanged && !IsClose)
        {
            Vector3 currentVelocity = rb.linearVelocity;
            center = ComputeCenterFromVelocity(transform.position, currentVelocity, forceMagnitude, rb.mass);
        }

        prevIsClose = IsClose;

        if (IsClose)
        {
            if (Status.IsGrounded)
            {
                Vector3 directionToPlayer = Player.transform.position - transform.position;
                rb.AddForce(directionToPlayer * 50.0f, ForceMode.Force);
            }
        }
        else
        {
            if (transform.position.z <= -80)
                rb.AddForce(Vector3.forward * 50.0f, ForceMode.Force);
            else if (transform.position.z >= 780)
                rb.AddForce(Vector3.back * 50.0f, ForceMode.Force);
            else if (transform.position.x <= -180)
                rb.AddForce(Vector3.right * 50.0f, ForceMode.Force);
            else if (transform.position.x >= 660)
                rb.AddForce(Vector3.left * 50.0f, ForceMode.Force);
            else
            {
                Vector3 directionToCenter = (center.position - transform.position).normalized;
                rb.AddForce(directionToCenter * forceMagnitude, ForceMode.Force);
            }
        }
    }
    Transform ComputeCenterFromVelocity(Vector3 position, Vector3 velocity, float forceMagnitude, float mass = 1f)
    {
        if (velocity == Vector3.zero || forceMagnitude == 0f)
            return null;

        float speed = velocity.magnitude;
        float radius = (mass * speed * speed) / forceMagnitude;

        Vector3 normal = Vector3.up;
        Vector3 centerDirection = Vector3.Cross(normal, velocity).normalized;

        GameObject centerObject = new GameObject("ComputedCenter");
        centerObject.transform.position = position + centerDirection * radius;

        return centerObject.transform;
    }

}
