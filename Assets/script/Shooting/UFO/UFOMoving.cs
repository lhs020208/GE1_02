using UnityEngine;

public class UFOMoving : MonoBehaviour
{
    Rigidbody rb;
    public Transform center; // ȸ�� �߽�
    public float speed = 100f; // �ʱ� �ӵ�
    public float forceMagnitude = 200f; // �߽��� ���� ���ɷ� ����

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        if (center == null)
        {
            GameObject c = new GameObject("AutoCenter");
            c.transform.position = transform.position - transform.right * 50f;
            center = c.transform;
        }


        Vector3 tangent = Vector3.Cross(Vector3.up, (transform.position - center.position).normalized);
        rb.linearVelocity = tangent * speed;
    }

    void FixedUpdate()
    {
        Vector3 directionToCenter = (center.position - transform.position).normalized;
        rb.AddForce(directionToCenter * forceMagnitude, ForceMode.Force);
        transform.up = Vector3.up;
        transform.forward = rb.linearVelocity.normalized;
    }
}
