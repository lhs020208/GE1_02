using UnityEngine;

public class DistanceBasedCollider : MonoBehaviour
{
    public GameObject Player_OBJ;
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

        Transform player = Player_OBJ.transform;
        var colliders = Object.FindObjectsByType<DistanceBasedCollider>(FindObjectsSortMode.None);
        foreach (var dbc in colliders)
        {
            dbc.targets = new Transform[] { player };
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
}
