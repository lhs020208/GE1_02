using UnityEngine;

public class SaveEdit : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] SavePoints = new GameObject[5];
    public Vector3[] SavePointsPos = new Vector3[5];
    public int NowSavePoint = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        for (int i = 0; i < 5; i++)
        {
            SavePoints[i] = GameObject.Find("SavePoint (" + i + ")");
            if (SavePoints[i] != null)
            {
                SavePointsPos[i] = SavePoints[i].transform.position;
            }
            else
            {
                Debug.LogError("SavePoint (" + i + ")를 찾을 수 없습니다.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            NowSavePoint = (NowSavePoint + 4) % 5;
            SavePoints[NowSavePoint].SetActive(true);
            Player.transform.position = SavePointsPos[NowSavePoint];
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            NowSavePoint = (NowSavePoint + 1) % 5;
            SavePoints[NowSavePoint].SetActive(true);
            Player.transform.position = SavePointsPos[NowSavePoint];
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NowSavePoint = 0;
            SavePoints[NowSavePoint].SetActive(true);
            Player.transform.position = SavePointsPos[NowSavePoint];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            NowSavePoint = 1;
            SavePoints[NowSavePoint].SetActive(true);
            Player.transform.position = SavePointsPos[NowSavePoint];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            NowSavePoint = 2;
            SavePoints[NowSavePoint].SetActive(true);
            Player.transform.position = SavePointsPos[NowSavePoint];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            NowSavePoint = 3;
            SavePoints[NowSavePoint].SetActive(true);
            Player.transform.position = SavePointsPos[NowSavePoint];
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            NowSavePoint = 4;
            SavePoints[NowSavePoint].SetActive(true);
            Player.transform.position = SavePointsPos[NowSavePoint];
        }
    }
}
