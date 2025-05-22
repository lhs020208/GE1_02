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
            Debug.LogError("village 오브젝트를 찾을 수 없습니다.");
            return;
        }

        // 1. Physics Material 로드
        PhysicsMaterial material = AssetDatabase.LoadAssetAtPath<PhysicsMaterial>("Assets/P_Material/Load.physicMaterial");
        if (material == null)
        {
            Debug.LogError("Assets/P_Material/Load.physicMaterial 파일을 찾을 수 없습니다!");
            return;
        }

        int appliedCount = 0;

        // 2. city (0) ~ city (7) 반복
        for (int i = 0; i <= 7; i++)
        {
            string cityName = $"city ({i})";
            Transform city = root.transform.Find(cityName);
            if (city == null)
            {
                Debug.LogWarning($"{cityName} 을(를) 찾을 수 없습니다.");
                continue;
            }

            Transform riverLine = city.Find("river_line");
            if (riverLine == null)
            {
                Debug.LogWarning($"{cityName} 안에 'river_line' 오브젝트가 없습니다.");
                continue;
            }

            // river_line 하위 오브젝트에 대해 적용
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

        Debug.Log($"'load' 물리 머티리얼이 적용된 Collider 수: {appliedCount}");
    }
}
