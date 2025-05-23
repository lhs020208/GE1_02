using UnityEngine;

public class MapCameraMove : MonoBehaviour
{
    public GameObject Player;
    public float Up_Distance = 5.0f; // ī�޶��� Y�� ��ġ ����
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
