using UnityEngine;
using UnityEngine.Animations;

public class BulletMove : MonoBehaviour
{
    public GameObject CloseUFO;
    public GameObject Player;
    public PlayerStatusManager status;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        status = Player.GetComponent<PlayerStatusManager>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status.ShootType != 0)
        {
            if (CloseUFO != null)
            {
                Vector3 toTarget = (CloseUFO.transform.position - transform.position).normalized;
                float speed = rb.linearVelocity.magnitude;
                rb.linearVelocity = toTarget * speed;
            }
        }
    }

    
}
