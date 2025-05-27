using UnityEngine;
public class Boost : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody rb;

    public float PlusSurfaceTension = 200.0f;
    public float BoostForce = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            rb.AddForce(-Player.transform.up * PlusSurfaceTension, ForceMode.Force);
            rb.AddForce(Player.transform.forward * BoostForce, ForceMode.Force);
        }
    }
}
