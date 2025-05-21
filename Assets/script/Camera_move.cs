using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.UIElements;

public class Camera_move : MonoBehaviour
{
    public GameObject Player;
    int Camera_pos = 3;
    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null) print("no Player");
        /*
         *      0
         *    3   1
         *      2
         */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Camera_pos = 3;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            Camera_pos = 2;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            Camera_pos = 1;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Camera_pos = 0;


        switch (Camera_pos)
        {
            case 0:
                transform.position = Player.transform.position
                   + Player.transform.forward * 5.0f
                   + Player.transform.up * 2.0f;
                break;
            case 1:
                transform.position = Player.transform.position
                   + Player.transform.right * -5.0f
                   + Player.transform.up * 2.0f;
                break;
            case 2:
                transform.position = Player.transform.position
                   + Player.transform.forward * -5.0f
                   + Player.transform.up * 2.0f;
                break;
            case 3:
                transform.position = Player.transform.position
                  + Player.transform.right * 5.0f
                  + Player.transform.up * 2.0f;
                break;
        }

        transform.LookAt(Player.transform);
        Player.transform.forward = transform.forward;
    }
}