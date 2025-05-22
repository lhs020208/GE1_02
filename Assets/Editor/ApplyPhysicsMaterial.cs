using UnityEngine;
using UnityEditor;

public class ApplyPhysicsMaterial
{
    [MenuItem("Tools/Apply 'load' PhysicMaterial to river_line")]
    public static void ApplyLoadMaterialToRiverLine()
    {
        // 1. village > city > river_line 찾아오기
        GameObject root = GameObject.Find("village/city (7)/river_line");
        if (root == null)
        {
            Debug.LogError("village/city/river_line 오브젝트를 찾을 수 없습니다.");
            return;
        }

        // 2. Physics Material 로드
        PhysicsMaterial material = AssetDatabase.LoadAssetAtPath<PhysicsMaterial>("Assets\\P_Material\\Load.physicMaterial");
        if (material == null)
        {
            Debug.LogError("Assets/P_Materials/Load 파일을 찾을 수 없습니다!!");
            return;
        }

        int appliedCount = 0;

        // 3. 하위 모든 오브젝트에서 Collider가 있는 경우 적용
        foreach (Transform child in root.GetComponentsInChildren<Transform>(true))
        {
            Collider col = child.GetComponent<Collider>();
            if (col != null)
            {
                col.material = material;
                appliedCount++;
            }
        }

        Debug.Log($"'load' 물리 머티리얼이 적용된 Collider 수: {appliedCount}");
    }
}
