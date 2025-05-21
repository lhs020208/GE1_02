using UnityEngine;

public class Player_reset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0.0f)
        {
            transform.position = new Vector3(15, 7, 698);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            transform.position = new Vector3(15, 7, 698);
        }
    }
}
