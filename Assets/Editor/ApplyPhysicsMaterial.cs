using UnityEngine;
using UnityEditor;

public class ApplyPhysicsMaterial
{
    [MenuItem("Tools/Apply 'load' PhysicMaterial to river_line")]
    public static void ApplyLoadMaterialToRiverLine()
    {
        // 1. village > city > river_line ã�ƿ���
        GameObject root = GameObject.Find("village/city (7)/river_line");
        if (root == null)
        {
            Debug.LogError("village/city/river_line ������Ʈ�� ã�� �� �����ϴ�.");
            return;
        }

        // 2. Physics Material �ε�
        PhysicsMaterial material = AssetDatabase.LoadAssetAtPath<PhysicsMaterial>("Assets\\P_Material\\Load.physicMaterial");
        if (material == null)
        {
            Debug.LogError("Assets/P_Materials/Load ������ ã�� �� �����ϴ�!!");
            return;
        }

        int appliedCount = 0;

        // 3. ���� ��� ������Ʈ���� Collider�� �ִ� ��� ����
        foreach (Transform child in root.GetComponentsInChildren<Transform>(true))
        {
            Collider col = child.GetComponent<Collider>();
            if (col != null)
            {
                col.material = material;
                appliedCount++;
            }
        }

        Debug.Log($"'load' ���� ��Ƽ������ ����� Collider ��: {appliedCount}");
    }
}
