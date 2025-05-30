using UnityEngine;

public class Save : MonoBehaviour
{
    public GameObject Player;
    public Player_Reset_R PRR;
    public Rigidbody rb;
    public bool Dynamic = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        rb = Player.GetComponent<Rigidbody>();
        PRR = Player.GetComponent<Player_Reset_R>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            PRR.initPosition = Player.transform.position;
            PRR.initRotation = Player.transform.rotation;
            if (PRR.Ceiling != null)
            {
                PRR.ceilingInitPosition = PRR.Ceiling.transform.position;
                PRR.ceilingInitRotation = PRR.Ceiling.transform.rotation;
            }
            Destroy(gameObject);
            if (Dynamic)
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            else
                rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }
}

