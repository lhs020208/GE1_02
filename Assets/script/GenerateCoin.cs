using UnityEngine;

public class GenerateCoin : MonoBehaviour
{
    public GameObject Coin;
    public bool IsCoin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void TriggerCoin()
    {
        if (!IsCoin)
        {
            GameObject newCoin = Instantiate(Coin, transform.position, Quaternion.identity);
            var generator = newCoin.GetComponent<CoinScript>();
            if (generator != null)
            {
                generator.IsCoin = true;
            }
            IsCoin = true;
        }
        gameObject.SetActive(false); // 이 시점에 비활성화
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
