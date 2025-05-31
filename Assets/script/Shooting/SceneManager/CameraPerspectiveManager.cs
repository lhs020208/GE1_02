using UnityEngine;

public class CameraPerspectiveManager : MonoBehaviour
{
    CheckUFOs checkUFOs;

    GameObject Camera;
    CameraMove CameraMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkUFOs = GetComponent<CheckUFOs>();
        Camera = GameObject.Find("Main Camera");
        CameraMove = Camera.GetComponent<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (checkUFOs.cnt == 0)
        {
            CameraMove.FirstPerspective = true;
        }
    }
}
