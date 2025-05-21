using UnityEngine;

public class Creat_Gold : MonoBehaviour
{
    public GameObject[] goldPrefab = new GameObject[10];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
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
            Instantiate(goldPrefab[i], new Vector3(x, 5.7f, z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
