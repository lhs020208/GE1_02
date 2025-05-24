using UnityEngine;

public class UFOsStatusManager : MonoBehaviour
{

    public GameObject Player;
    public Rigidbody rb;
    public bool CenterMoving = true;
    public Transform center;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Player = GameObject.Find("Player");
        if (Player == null)
        {
            Debug.LogError("Player 오브젝트를 찾을 수 없습니다.");
            this.enabled = false;
            return;
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
