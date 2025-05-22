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
            // BoxCollider가 있다면 제거
            BoxCollider box = child.GetComponent<BoxCollider>();
            if (box != null)
            {
                Object.DestroyImmediate(box);
            }

            // MeshFilter가 있고, MeshCollider가 없다면 추가
            if (child.GetComponent<MeshFilter>() != null && child.GetComponent<MeshCollider>() == null)
            {
                MeshCollider mesh = child.gameObject.AddComponent<MeshCollider>();
                mesh.convex = false; // 필요에 따라 true 가능
                count++;
            }
        }

        Debug.Log($" MeshCollider 추가 완료 (총 {count}개), 기존 BoxCollider는 제거됨");
    }
}
