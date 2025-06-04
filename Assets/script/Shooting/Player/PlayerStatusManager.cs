using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerStatusManager : MonoBehaviour
{
    public bool IsContact = false;
    public bool PushW = false;
    public bool PushS = false;
    public bool PushA = false;
    public bool PushD = false;
    public bool PushQ = false;
    public bool PushE = false;
    public bool ClickL = false;

    Vector2 MoveBasedY;

    public GameObject CloseUFO;
    public GameObject SM;
    public CheckUFOs checkufos;
    public int ShootType = 0;

    public float closestDistance = Mathf.Infinity;
    public GameObject[] allUFOs;
    void Start()
    {
        allUFOs = GameObject.FindGameObjectsWithTag("UFO");
        SM = GameObject.Find("SceneManager");
        checkufos = SM.GetComponent<CheckUFOs>();
    }

    void Update()
    {
        PushW = MoveBasedY.y > 0;
        PushS = MoveBasedY.y < 0;
        PushA = MoveBasedY.x < 0;
        PushD = MoveBasedY.x > 0;

        if (Input.GetKeyDown(KeyCode.Q))
            PushQ = true;
        if (Input.GetKeyUp(KeyCode.Q))
            PushQ = false;
        if (Input.GetKeyDown(KeyCode.E))
            PushE = true;
        if (Input.GetKeyUp(KeyCode.E))
            PushE = false;
        if (Input.GetMouseButtonDown(0))
            ClickL = true;
        if (Input.GetMouseButtonUp(0))
            ClickL = false;


        if (Input.GetKeyDown(KeyCode.O))
            ShootType = (ShootType + 1) % 3;
        
        CloseUFO = null;
        closestDistance = Mathf.Infinity;

        GameObject[] allUFOs = GameObject.FindGameObjectsWithTag("UFO");

        foreach (GameObject ufo in allUFOs)
        {
            if (ufo == null) continue;

            float distance = Vector3.Distance(transform.position, ufo.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                CloseUFO = ufo;
            }
        }
    }
    void OnCollisionStay(Collision collision)
    {
        foreach (var contact in collision.contacts)
        {
            IsContact = true;
            return;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        IsContact = false;
    }

    void OnMove(InputValue value)
    {
        MoveBasedY = value.Get<Vector2>();
    }
}
