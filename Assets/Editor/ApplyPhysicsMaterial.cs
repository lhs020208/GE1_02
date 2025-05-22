using UnityEngine;
using UnityEditor;

public class ApplyPhysicsMaterial
{
    [MenuItem("Tools/Apply 'load' PhysicMaterial to all river_line")]
    public static void ApplyLoadMaterialToRiverLine()
    {
        GameObject root = GameObject.Find("village");
        if (root == null)
        {
            Debug.LogError("village ������Ʈ�� ã�� �� �����ϴ�.");
            return;
        }

        // 1. Physics Material �ε�
        PhysicsMaterial material = AssetDatabase.LoadAssetAtPath<PhysicsMaterial>("Assets/P_Material/Load.physicMaterial");
        if (material == null)
        {
            Debug.LogError("Assets/P_Material/Load.physicMaterial ������ ã�� �� �����ϴ�!");
            return;
        }

        int appliedCount = 0;

        // 2. city (0) ~ city (7) �ݺ�
        for (int i = 0; i <= 7; i++)
        {
            string cityName = $"city ({i})";
            Transform city = root.transform.Find(cityName);
            if (city == null)
            {
                Debug.LogWarning($"{cityName} ��(��) ã�� �� �����ϴ�.");
                continue;
            }

            Transform riverLine = city.Find("river_line");
            if (riverLine == null)
            {
                Debug.LogWarning($"{cityName} �ȿ� 'river_line' ������Ʈ�� �����ϴ�.");
                continue;
            }

            // river_line ���� ������Ʈ�� ���� ����
            foreach (Transform child in riverLine.GetComponentsInChildren<Transform>(true))
            {
                Collider col = child.GetComponent<Collider>();
                if (col != null)
                {
                    col.material = material;
                    appliedCount++;
                }
            }
        }

        Debug.Log($"'load' ���� ��Ƽ������ ����� Collider ��: {appliedCount}");
    }
}
