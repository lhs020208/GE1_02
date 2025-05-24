using UnityEngine;

public class DistanceBasedCollider : MonoBehaviour
{
    /*
    public GameObject Player_OBJ;
    public GameObject[] UFO = new GameObject[10];

    public Transform[] targets;
    public float activateDistance = 100.0f;

    private Collider col;

    void Start()
    {
        col = GetComponent<Collider>();
        if (col == null)
        {
            this.enabled = false;
            return;
        }

        Player_OBJ = GameObject.Find("Player");
        if (Player_OBJ == null)
        {
            this.enabled = false;
            return;
        }
        for (int i = 0; i < 10; i ++)
        {
            UFO[i] = GameObject.Find("UFO (" + i + ")");
            if (UFO[i] == null)
            {
                this.enabled = false;
                return;
            }
        }

        targets = new Transform[11];
        targets[0] = Player_OBJ.transform;
        for (int i = 0; i < 10; i++)
        {
            targets[i + 1] = UFO[i].transform;
        }
    }

    void Update()
    {
        if (col == null || targets == null || targets.Length == 0) return;

        bool shouldEnable = false;
        foreach (Transform t in targets)
        {
            if (t != null && Vector3.Distance(t.position, transform.position) <= activateDistance)
            {
                shouldEnable = true;
                break;
            }
        }

        col.enabled = shouldEnable;
    }
    */
}
