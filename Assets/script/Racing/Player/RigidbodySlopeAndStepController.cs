using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodySlopeAndStepController : MonoBehaviour
{
    [Header("Slope Limit")]
    public float slopeLimit = 45f;
    public float slopeSlideForce = 10f;

    [Header("Step Offset")]
    public float stepHeight = 0.4f;
    public float stepCheckDistance = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        HandleSlope();
        //HandleStepOffset();
    }

    void HandleSlope()
    {
        RaycastHit hit;
        Vector3 origin = transform.position + Vector3.up * 0.1f;

        if (Physics.Raycast(origin, Vector3.down, out hit, 0.3f, groundLayer))
        {
            float angle = Vector3.Angle(hit.normal, Vector3.up);

            if (angle > slopeLimit)
            {
                // 경사 제한 초과 → 미끄러지게 처리
                Vector3 slideDir = Vector3.ProjectOnPlane(Vector3.down, hit.normal).normalized;
                rb.AddForce(slideDir * slopeSlideForce, ForceMode.Acceleration);
            }
        }
    }

    void HandleStepOffset()
    {
        Vector3[] directions = new Vector3[]
        {
            transform.forward,
            (transform.forward + transform.right).normalized,
            (transform.forward - transform.right).normalized
        };

        foreach (var dir in directions)
        {
            Vector3 lowOrigin = transform.position + Vector3.up * 0.05f;
            Vector3 highOrigin = transform.position + Vector3.up * stepHeight;

            // 아래쪽 레이: 벽 감지
            if (Physics.Raycast(lowOrigin, dir, stepCheckDistance, groundLayer))
            {
                // 위쪽 레이: 턱 위가 비어있으면 step 가능
                if (!Physics.Raycast(highOrigin, dir, stepCheckDistance, groundLayer))
                {
                    // stepHeight만큼 살짝 들어올림
                    rb.MovePosition(rb.position + Vector3.up * stepHeight);
                    break;
                }
            }
        }
    }
}
