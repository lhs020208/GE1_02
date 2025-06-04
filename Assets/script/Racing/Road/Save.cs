using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public GameObject Player;
    public PlayerResetR PRR;
    public Rigidbody rb;
    public bool Dynamic = false;

    public GameObject SceneManager;
    public SaveEdit saveEditScript;
    public int SaveNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");
        SceneManager = GameObject.Find("SceneManager");
        saveEditScript = SceneManager.GetComponent<SaveEdit>();
        rb = Player.GetComponent<Rigidbody>();
        PRR = Player.GetComponent<PlayerResetR>();

        string name = gameObject.name;
        int start = name.IndexOf('(');
        int end = name.IndexOf(')');
        if (start != -1 && end != -1 && end > start + 1)
        {
            string numberStr = name.Substring(start + 1, end - start - 1);
            if (int.TryParse(numberStr, out int parsedNumber))
            {
                SaveNumber = parsedNumber;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            PRR.initPosition = Player.transform.position;
            PRR.initRotation = Player.transform.rotation;
            if (PRR.Ceiling != null)
            {
                PRR.ceilingInitPosition = PRR.Ceiling.transform.position;
                PRR.ceilingInitRotation = PRR.Ceiling.transform.rotation;
            }
            if (Dynamic)
                rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            else
                rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

            gameObject.SetActive(false);
            saveEditScript.NowSavePoint = SaveNumber;
        }
    }
}

