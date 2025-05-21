using UnityEngine;

public class Gold_spin : MonoBehaviour
{
    float spin_speed = 50.0f;
    float move_speed = 0.5f;
    int direct = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //y축 기준으로 회전
        transform.Rotate(0, Time.deltaTime * spin_speed, 0);
        if (transform.position.y >= 6.5)
        {
            direct = -1;
        }
        else if ( transform.position.y <= 5.7)
        {
            direct = 1;
        }
        transform.position += new Vector3(0, Time.deltaTime * direct * move_speed, 0);
    }
}
