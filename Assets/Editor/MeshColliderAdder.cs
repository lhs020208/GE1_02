using UnityEngine;
using UnityEditor;

public class MeshColliderAdder
{
    /*
    [MenuItem("Tools/Add DistanceBasedCollider to all children")]
    public static void AddMeshColliders()
    {
        GameObject root = GameObject.Find("village");

        if (root == null)
        {
            Debug.LogError("village ������Ʈ�� ã�� �� �����ϴ�!");
            return;
        }

        int addedCount = 0;
        Transform[] allChildren = root.GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allChildren)
        {
            if (child.GetComponent<DistanceBasedCollider>() == null)
            {
                DistanceBasedCollider dist = child.gameObject.AddComponent<DistanceBasedCollider>();
                dist.activateDistance = 50.0f;
                addedCount++;
            }
        }

        Debug.Log($"DistanceBasedCollider �߰� �Ϸ�: {addedCount}�� ������Ʈ�� �����");
    }
    */
}
