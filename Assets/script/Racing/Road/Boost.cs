using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Boost : MonoBehaviour
{
    public Rigidbody rb;
    public float PlusSurfaceTension = 20.0f;
    public float BoostForce = 30.0f;
    public GameObject Player;

    private void Start()
    {
        if (rb == null)
        {
            Player = GameObject.Find("Player");
            if (Player != null) rb = Player.GetComponent<Rigidbody>();
        }
    }
    void OnCollisionStay(Collision collision)
    {
        rb.AddForce(-Player.transform.up * PlusSurfaceTension, ForceMode.Force);
        rb.AddForce(Player.transform.forward * BoostForce, ForceMode.Force);
    }
}
