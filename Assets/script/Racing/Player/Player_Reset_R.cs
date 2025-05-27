using UnityEngine;

public class Player_Reset_R : MonoBehaviour
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
        if (transform.position.y <= -10.0f)
        {
            ResetTransform();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetTransform();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SavePoint")
        {
            initPosition = transform.position;
            initRotation = transform.rotation;

            if (Ceiling != null)
            {
                ceilingInitPosition = Ceiling.transform.position;
                ceilingInitRotation = Ceiling.transform.rotation;
            }
            Destroy(other.gameObject);
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
