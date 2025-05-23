using UnityEngine;

public class MapCameraMove : MonoBehaviour
{
    public GameObject Player;
    public float Up_Distance = 5.0f; // 카메라의 Y축 위치 조정
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null) print("no Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + Up_Distance, Player.transform.position.z);
    }
}
