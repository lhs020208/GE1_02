using UnityEngine;

public class Player_Reset : MonoBehaviour
{
    private Vector3 initPosition;
    private Quaternion initRotation;
    private Rigidbody rb;

    public GameObject Ceiling;
    private Vector3 ceilingInitPosition;
    private Quaternion ceilingInitRotation;

    void Start()
    {
        initPosition = transform.position;
        initRotation = transform.rotation;

        if (Ceiling != null)
        {
            ceilingInitPosition = Ceiling.transform.position;
            ceilingInitRotation = Ceiling.transform.rotation;
        }

        rb = GetComponent<Rigidbody>();
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

        if (Ceiling != null)
        {
            Ceiling.transform.position = ceilingInitPosition;
            Ceiling.transform.rotation = ceilingInitRotation;
        }
    }
}
