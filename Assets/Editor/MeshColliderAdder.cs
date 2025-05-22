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
            // BoxCollider�� �ִٸ� ����
            BoxCollider box = child.GetComponent<BoxCollider>();
            if (box != null)
            {
                Object.DestroyImmediate(box);
            }

            // MeshFilter�� �ְ�, MeshCollider�� ���ٸ� �߰�
            if (child.GetComponent<MeshFilter>() != null && child.GetComponent<MeshCollider>() == null)
            {
                MeshCollider mesh = child.gameObject.AddComponent<MeshCollider>();
                mesh.convex = false; // �ʿ信 ���� true ����
                count++;
            }
        }

        Debug.Log($" MeshCollider �߰� �Ϸ� (�� {count}��), ���� BoxCollider�� ���ŵ�");
    }
}
