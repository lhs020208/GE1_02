using Unity.VisualScripting;
using UnityEngine;

public class UFOMoving : MonoBehaviour
{
    Rigidbody rb;
    public Transform center; // 회전 중심
    public GameObject Player;

    public float speed = 100f; // 초기 속도
    public float forceMagnitude = 200f; // 중심을 향한 구심력 세기
    public float SencerDistance = 10.0f;

    float DistancePlayerVsMe;
    bool IsClose;
    bool prevIsClose = false;
    public bool IsCloseChanged { get; private set; }


    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null) print("no Player");

            rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Vector3 initialVelocity = transform.forward * speed;

        if (center == null)
        {
            center = ComputeCenterFromVelocity(transform.position, initialVelocity, forceMagnitude, rb.mass);
        }
        IsCloseChanged = (IsClose != prevIsClose);
        prevIsClose = IsClose;

        Vector3 tangent = Vector3.Cross(Vector3.up, (transform.position - center.position).normalized);
        rb.linearVelocity = tangent * speed;
    }
    void Update()
    {
        DistancePlayerVsMe = Vector3.Distance(transform.position, Player.transform.position);
        if (DistancePlayerVsMe < SencerDistance) IsClose = true;
        else IsClose = false;
    }

    void FixedUpdate()
    {
        if (IsClose)
        {
            if (!IsCloseChanged)
            {
                Vector3 initialVelocity = transform.forward * speed;
                center = ComputeCenterFromVelocity(transform.position, initialVelocity, forceMagnitude, rb.mass);
            }
            Vector3 directionToCenter = (center.position - transform.position).normalized;
            rb.AddForce(directionToCenter * forceMagnitude, ForceMode.Force);
            transform.forward = rb.linearVelocity.normalized;
        }
        else
        {
            Vector3 directionToCenter = transform.position - Player.transform.position;
            rb.AddForce(directionToCenter * 1.0f, ForceMode.Force);
            transform.forward = rb.linearVelocity.normalized;
            print("플레이어 딱대");
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
