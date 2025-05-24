using UnityEngine;

public class UFOsShrapnel : MonoBehaviour
{
    public float maxForce = 200.0f;
    public int lifetimeThreshold = 1000;

    private Vector3 spinAxis;
    private int timer = 0;

    void Start()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        spinAxis = new Vector3(x, y, z);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 randomDir = Random.onUnitSphere;
            float randomMag = Random.Range(0f, maxForce);
            rb.AddForce(randomDir * randomMag, ForceMode.Impulse);
        }
    }

    void Update()
    {
        transform.Rotate(spinAxis);

        timer++;
        if (timer > lifetimeThreshold)
        {
            if (Random.value < 0.01f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
