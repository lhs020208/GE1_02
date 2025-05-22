using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.UIElements;

public class Camera_move : MonoBehaviour
{
    public GameObject Player;
    public bool FirstPerspective = true;

    public float Up_Distance = 1.5f;
    public float Back_Distance = 3.0f;
    public float LookAhead_Distance = 3.0f;

    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null) print("no Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (FirstPerspective)
        {
            Vector3 offset = -Player.transform.forward * Back_Distance + Vector3.up * Up_Distance;

            transform.position = Player.transform.position + offset;

            transform.LookAt(Player.transform.position + Player.transform.forward * LookAhead_Distance);
        }
    }
}