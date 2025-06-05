using UnityEngine;
using UnityEditor;

public class ApplyPhysicsMaterial
{
    [MenuItem("Tools/Apply 'NormalObj' Material to all MeshColliders with no material")]
    public static void ApplyNormalMaterialToMeshColliders()
    {
        // 물리 머티리얼 로드
        PhysicsMaterial material = AssetDatabase.LoadAssetAtPath<PhysicsMaterial>("Assets/P_Material/NormalObj.physicMaterial");
        if (material == null)
        {
            Debug.LogError("Assets/P_Material/NormalObj.physicMaterial 파일을 찾을 수 없습니다!");
            return;
        }

        int appliedCount = 0;

        // 최신 API 사용 (정렬 없음 → 더 빠름)
        GameObject[] allObjects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        foreach (GameObject obj in allObjects)
        {
            BoxCollider meshCol = obj.GetComponent<BoxCollider>();
            if (meshCol != null && meshCol.sharedMaterial == null)
            {
                meshCol.sharedMaterial = material;
                appliedCount++;
            }
        }

        Debug.Log($"MeshCollider에 'NormalObj' 물리 머티리얼이 적용된 수: {appliedCount}");
    }
}
