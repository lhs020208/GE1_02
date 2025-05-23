using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    PlayerStatusManager Status;
    public GameObject Player;
    public bool FirstPerspective = true;

    public float Up_Distance = 1.5f;
    public float Back_Distance = 3.0f;
    public float LookAhead_Distance = 3.0f;

    Vector3 LastSaveForward;

    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null) print("no Player");
        Status = Player.GetComponent<PlayerStatusManager>();
        LastSaveForward = Player.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Status != null && Status.IsGrounded)
        {
            Vector3 playerForward = Player.transform.forward.normalized;
            LastSaveForward = Vector3.RotateTowards(
                LastSaveForward,
                playerForward,
                Time.deltaTime * 5f, // 회전 속도 조절 (값이 클수록 빠르게 회전)
                0.0f
            );
        }
        if (FirstPerspective)
        {
            Vector3 offset = -LastSaveForward * Back_Distance + Vector3.up * Up_Distance;

            transform.position = Player.transform.position + offset;

            transform.LookAt(Player.transform.position + LastSaveForward * LookAhead_Distance);
        }
    }
}