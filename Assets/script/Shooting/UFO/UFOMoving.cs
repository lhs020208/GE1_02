using Unity.VisualScripting;
using UnityEngine;

public class UFOMoving : MonoBehaviour
{
    PlayerStatusManager PlayerStatus;
    UFOsStatusManager UFOsStatus;

    public float speed = 100f; // 초기 속도
    public float forceMagnitude = 200f; // 중심을 향한 구심력 세기
    public float SencerDistance = 500.0f;

    float DistancePlayerVsMe;
    public bool IsClose;
    bool prevIsClose = false;
    public bool IsCloseChanged { get; private set; }


    void Start()
    {
        UFOsStatus = GetComponent<UFOsStatusManager>();
        PlayerStatus = UFOsStatus.Player.GetComponent<PlayerStatusManager>();

        float randomY = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, randomY, 0f);

        Vector3 initialVelocity = transform.forward * speed;

        if (UFOsStatus.center == null)
        {
            UFOsStatus.center = ComputeCenterFromVelocity(transform.position, initialVelocity, forceMagnitude, UFOsStatus.rb.mass);
        }
        IsCloseChanged = false;
        prevIsClose = IsClose;

        Vector3 tangent = Vector3.Cross(Vector3.up, (transform.position - UFOsStatus.center.position).normalized);
        UFOsStatus.rb.linearVelocity = tangent * speed;
    }
    void Update()
    {
    }
    void FixedUpdate()
    {
        if (!UFOsStatus.rb.useGravity)
        {
            DistancePlayerVsMe = Vector3.Distance(transform.position, UFOsStatus.Player.transform.position);
            IsClose = DistancePlayerVsMe < SencerDistance;
            IsCloseChanged = (IsClose != prevIsClose);

            if (IsCloseChanged && !IsClose)
            {
                Vector3 currentVelocity = UFOsStatus.rb.linearVelocity;
                UFOsStatus.center = ComputeCenterFromVelocity(transform.position, currentVelocity, forceMagnitude, UFOsStatus.rb.mass);
            }

            prevIsClose = IsClose;

            if (IsClose)
            {
                if (!PlayerStatus.IsGrounded)
                {
                    Vector3 directionToPlayer = UFOsStatus.Player.transform.position - transform.position;
                    UFOsStatus.rb.AddForce(directionToPlayer * 1.0f, ForceMode.Force);
                    UFOsStatus.CenterMoving = false;
                }
            }
            else
            {
                if (transform.position.z <= -80)
                {
                    UFOsStatus.rb.AddForce(Vector3.forward * 50.0f, ForceMode.Force);
                    UFOsStatus.CenterMoving = false;
                }
                else if (transform.position.z >= 780)
                {
                    UFOsStatus.rb.AddForce(Vector3.back * 50.0f, ForceMode.Force);
                    UFOsStatus.CenterMoving = false;
                }
                else if (transform.position.x <= -180)
                {
                    UFOsStatus.rb.AddForce(Vector3.right * 50.0f, ForceMode.Force);
                    UFOsStatus.CenterMoving = false;
                }
                else if (transform.position.x >= 660)
                {
                    UFOsStatus.rb.AddForce(Vector3.left * 50.0f, ForceMode.Force);
                    UFOsStatus.CenterMoving = false;
                }
                else
                {
                    Vector3 directionToCenter = (UFOsStatus.center.position - transform.position).normalized;
                    UFOsStatus.rb.AddForce(directionToCenter * forceMagnitude, ForceMode.Force);
                    UFOsStatus.CenterMoving = true;
                }
            }
        }
        else
        {
            UFOsStatus.rb.linearVelocity = new Vector3(
                UFOsStatus.rb.linearVelocity.x * 1/2, 
                UFOsStatus.rb.linearVelocity.y,
                UFOsStatus.rb.linearVelocity.z * 1/2);
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
