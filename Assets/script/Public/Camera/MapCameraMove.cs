using UnityEngine;

public class MapCameraMove : MonoBehaviour
{
    public GameObject Player;
    public float Up_Distance = 5.0f; // 카메라의 Y축 위치 조정
    public bool Minimap = true; // 미니맵 모드 여부
    public Camera C;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null) print("no Player");
        C = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + Up_Distance, Player.transform.position.z);
        if (Input.GetKeyDown(KeyCode.M))
            Minimap = !Minimap;

        if (Minimap)
            C.depth = -0.9f;
        else C.depth = -1.1f;
    }
}
