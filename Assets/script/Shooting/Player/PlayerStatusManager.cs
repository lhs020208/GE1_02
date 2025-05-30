using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerStatusManager : MonoBehaviour
{
    public bool IsGrounded = false;
    public bool PushW = false;
    public bool PushS = false;
    public bool PushA = false;
    public bool PushD = false;
    public bool PushQ = false;
    public bool PushE = false;
    Vector2 move;

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
        if (move.y > 0)
            PushW = true;
        else
            PushW = false;
        if (move.y < 0)
            PushS = true;
        else
            PushS = false;
        if (move.x < 0)
            PushA = true;
        else
            PushA = false;
        if (move.x > 0)
            PushD = true;
        else
            PushD = false;
        if (Input.GetKeyDown(KeyCode.Q))
            PushQ = true;
        if (Input.GetKeyUp(KeyCode.Q))
            PushQ = false;
        if (Input.GetKeyDown(KeyCode.E))
            PushE = true;
        if (Input.GetKeyUp(KeyCode.E))
            PushE = false;
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
            if (contact.normal.y > 0.5f)
            {
                IsGrounded = true;
                return;
            }
        }
        IsGrounded = false;
    }

    void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }

    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
