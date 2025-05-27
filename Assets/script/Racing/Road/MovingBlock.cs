using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public Rigidbody rb;
    public float minForce = 5f;
    public float maxForce = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float randomForce = Random.Range(minForce, maxForce);
        rb.AddForce(Vector3.forward * randomForce * -10000, ForceMode.Impulse);
    }
    void OnTriggerEnter(Collider other)
    {
        Vector3 incoming = rb.linearVelocity;
        Vector3 reflected = rb.linearVelocity;
        reflected.x *= -1;
        reflected.y *= -1;
        reflected.z *= -1;
        rb.linearVelocity = reflected;
    }
}
