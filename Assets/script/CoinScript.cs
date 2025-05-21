using System.Buffers.Text;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public bool IsCoin = false;
    private float spinSpeed = 720.0f;     // 초당 1바퀴 = 360도, 0.5초에 360도 → 720도/초
    private float moveSpeed = 3.2f;       // 0.25초에 0.8 이동
    private float moveTime = 0.0f;
    private int direction = 1;            // 1이면 위, -1이면 아래
    public GameObject goldPrefab;

    private float baseY;                  // 생성 y위치 저장용
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(0, 0, 90.0f);
        baseY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveAndEnabled && IsCoin)
        {
            transform.Rotate(Time.deltaTime * spinSpeed, 0, 0);

            moveTime += Time.deltaTime;

            if (direction == 1)
            {
                transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
                if (moveTime >= 0.25f)
                {
                    direction = -1;
                    moveTime = 0.0f;
                }
            }
            else if (direction == -1)
            {
                transform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
                if (moveTime >= 0.25f)
                {
                    int randx = Random.Range(0, 16);
                    int randz = Random.Range(0, 16);

                    // x 좌표 계산
                    float x = -15f;
                    for (int j = 0; j < randx; j++)
                    {
                        if (j % 2 == 0)
                            x += 30f;
                        else
                            x += 47.77f;
                    }

                    // z 좌표는 그대로
                    float z = 698.0f - randz * 43.6f;

                    // 오브젝트 생성
                    Instantiate(goldPrefab, new Vector3(x, 5.7f, z), Quaternion.identity);
                    gameObject.SetActive(false);
                }
            }
        }   
    }
}
