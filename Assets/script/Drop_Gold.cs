using UnityEngine;

public class Drop_Gold : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        var generator = collision.gameObject.GetComponent<GenerateCoin>();
        if (generator != null)
        {
            generator.TriggerCoin();
        }
    }
}
