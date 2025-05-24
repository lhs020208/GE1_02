using UnityEngine;

public class UFOsHP : MonoBehaviour
{
    public int HP = 10;
    UFOsStatusManager UFOsStatus;
    public GameObject UFOsHPBar;
    public GameObject Player;
    public GameObject Shrapnel;

    public float Height = 10.0f;
    public float BarSizse = 40.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UFOsStatus = GetComponent<UFOsStatusManager>();
        Player = GameObject.Find("Player");
        if (Player == null) print("no Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (UFOsHPBar != null)
        {
            UFOsHPBar.transform.localScale = new Vector3(BarSizse - ((10 - HP) * 4), 5.0f, 1.0f);
            UFOsHPBar.transform.position = new Vector3(transform.position.x + ((10 - HP) * 2), transform.position.y + Height, transform.position.z);
            UFOsHPBar.transform.LookAt(Player.transform.position);
        }
        if (transform.position.y < 0.0f)
        {
            KillUFO();
            for (int i = 0; i < 360; i++)
            {
                Instantiate(Shrapnel, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            KillUFO();
            for (int i = 0; i < 360; i++)
            {
                Instantiate(Shrapnel, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (HP > 0)
        {
            if (other.gameObject.tag == "Bullet")
            {
                HP--;
                Destroy(other.gameObject);
            }
        }
        else
        {
            if (UFOsHPBar != null)
            {
                KillUFO();
            }
        }
    }
    void KillUFO()
    {
        if (UFOsHPBar != null) Destroy(UFOsHPBar);
        UFOsStatus.rb.useGravity = true;
        UFOsStatus.CenterMoving = false;
    }
}


