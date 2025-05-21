using UnityEngine;

public class char_move : MonoBehaviour
{
    float speed = 5.0f;
    int move_x = 0;
    int move_z = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            move_z = 1;
        
        if (Input.GetKeyDown(KeyCode.S))
            move_z = -1;

        if (Input.GetKeyDown(KeyCode.A))
            move_x = -1;

        if (Input.GetKeyDown(KeyCode.D))
            move_x = 1;

        if (Input.GetKeyUp(KeyCode.W))
            move_z = 0;

        if (Input.GetKeyUp(KeyCode.S))
            move_z = 0;

        if (Input.GetKeyUp(KeyCode.A))
            move_x = 0;

        if (Input.GetKeyUp(KeyCode.D))
            move_x = 0;


        Vector3 input = new Vector3(move_x, 0, move_z).normalized;
        Vector3 move = transform.TransformDirection(input);
        move.y = 0;
        transform.position += move * Time.deltaTime * speed;
        transform.forward = new Vector3(0, 0, 1);


        Vector3 pos = transform.position;
        pos.y = Mathf.Ceil(pos.y * 100f) / 100f;
        transform.position = pos;
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 velocity = rb.linearVelocity;
        rb.linearVelocity = new Vector3(0, velocity.y, 0);
    }
}
