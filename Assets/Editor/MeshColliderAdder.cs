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
            Debug.LogError("village 오브젝트를 찾을 수 없습니다!");
            return;
        }

        int count = 0;
        Transform[] allChildren = root.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            if (child.GetComponent<MeshFilter>() != null && child.GetComponent<MeshCollider>() == null)
            {
                MeshCollider collider = child.gameObject.AddComponent<MeshCollider>();
                collider.convex = false; // 필요에 따라 true
                count++;
            }
        }

        Debug.Log($" MeshCollider가 추가된 오브젝트 수: {count}");
    }
}
