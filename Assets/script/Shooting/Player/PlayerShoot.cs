using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    PlayerStatusManager Status;
    public float shootForce = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Status = GetComponent<PlayerStatusManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);

            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direction = (Status.CloseUFO.transform.position - transform.position).normalized;
                rb.AddForce(direction * shootForce, ForceMode.Impulse);
            }
        }
    }
}
