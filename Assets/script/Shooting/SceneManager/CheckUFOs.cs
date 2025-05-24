using UnityEngine;

public class CheckUFOs : MonoBehaviour
{
    public GameObject[] ufos = new GameObject[10]; // Array to hold references to UFO GameObjects
    public int cnt = 10; // Counter for remaining UFOs
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cnt = 0;
        for (int i = 0; i < ufos.Length; i++)
        {
            if (ufos[i] != null)
            {
                cnt++;
            }
        }
    }
}
