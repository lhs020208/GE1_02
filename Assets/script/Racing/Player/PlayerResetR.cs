using UnityEngine;

public class PlayerResetR : MonoBehaviour
{
    public Vector3 initPosition;
    public Quaternion initRotation;
    public Rigidbody rb;

    public GameObject Ceiling;
    public Vector3 ceilingInitPosition;
    public Quaternion ceilingInitRotation;

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
        if (transform.position.y <= -10.0f)
        {
            ResetTransform();
        }
        if (Input.GetKeyDown(KeyCode.R))
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
