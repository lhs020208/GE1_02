using Unity.VisualScripting;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    int timer = 0;
    public int distance = 2000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer >= distance)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
