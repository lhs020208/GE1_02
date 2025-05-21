using UnityEngine;
using UnityEditor;

public class MeshColliderAdder
{
    [MenuItem("Tools/Add MeshColliders Recursively")]
    public static void AddMeshColliders()
    {
        GameObject root = GameObject.Find("village");

        if (root == null)
        {
            Debug.LogError("village ������Ʈ�� ã�� �� �����ϴ�!");
            return;
        }

        int count = 0;
        Transform[] allChildren = root.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            if (child.GetComponent<MeshFilter>() != null && child.GetComponent<MeshCollider>() == null)
            {
                MeshCollider collider = child.gameObject.AddComponent<MeshCollider>();
                collider.convex = false; // �ʿ信 ���� true
                count++;
            }
        }

        Debug.Log($" MeshCollider�� �߰��� ������Ʈ ��: {count}");
    }
}
