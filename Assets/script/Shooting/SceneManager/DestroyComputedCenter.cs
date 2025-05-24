using UnityEngine;

public class DestroyComputedCenter : MonoBehaviour
{
    CheckUFOs checkUFOs;
    bool AllDestroyed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkUFOs = GetComponent<CheckUFOs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AllDestroyed)
        {
            if (checkUFOs != null && checkUFOs.cnt == 0)
            {
                GameObject oldCenter = GameObject.Find("ComputedCenter");
                if (oldCenter != null)
                {
                    Destroy(oldCenter);
                }
                else AllDestroyed = true;
            }
        }
    }
}
