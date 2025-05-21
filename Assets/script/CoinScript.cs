using System.Buffers.Text;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public bool IsCoin = false;
    private float spinSpeed = 720.0f;     // �ʴ� 1���� = 360��, 0.5�ʿ� 360�� �� 720��/��
    private float moveSpeed = 3.2f;       // 0.25�ʿ� 0.8 �̵�
    private float moveTime = 0.0f;
    private int direction = 1;            // 1�̸� ��, -1�̸� �Ʒ�
    public GameObject goldPrefab;

    private float baseY;                  // ���� y��ġ �����
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

                    // x ��ǥ ���
                    float x = -15f;
                    for (int j = 0; j < randx; j++)
                    {
                        if (j % 2 == 0)
                            x += 30f;
                        else
                            x += 47.77f;
                    }

                    // z ��ǥ�� �״��
                    float z = 698.0f - randz * 43.6f;

                    // ������Ʈ ����
                    Instantiate(goldPrefab, new Vector3(x, 5.7f, z), Quaternion.identity);
                    gameObject.SetActive(false);
                }
            }
        }   
    }
}
