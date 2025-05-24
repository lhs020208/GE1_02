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
            Debug.LogError("village 오브젝트를 찾을 수 없습니다!");
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

        Debug.Log($"DistanceBasedCollider 추가 완료: {addedCount}개 오브젝트에 적용됨");
    }
    */
}
