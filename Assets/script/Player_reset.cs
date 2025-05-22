using UnityEngine;

public class Player_reset : MonoBehaviour
{
    private Vector3 initPosition;
    private Quaternion initRotation;
    private Rigidbody rb;

    void Start()
    {
        initPosition = transform.position;
        initRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody가 없습니다.");
        }
    }

    void Update()
    {
        if (transform.position.y <= 0.0f)
        {
            ResetTransform();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            ResetTransform();
        }
    }

    void ResetTransform()
    {
        transform.position = initPosition;
        transform.rotation = initRotation;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
