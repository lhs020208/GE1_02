using UnityEngine;
using UnityEditor;

public class ApplyPhysicsMaterial
{
    [MenuItem("Tools/Set Layer 'Road' to Objects Using Road PhysicMaterial")]
    public static void SetLayerToRoadMaterialObjects()
    {
        // 물리 머티리얼 로드
        PhysicsMaterial roadMaterial = AssetDatabase.LoadAssetAtPath<PhysicsMaterial>("Assets/P_Material/Road.physicMaterial");
        if (roadMaterial == null)
        {
            Debug.LogError("Assets/P_Material/Road.physicMaterial 파일을 찾을 수 없습니다!");
            return;
        }

        int updatedCount = 0;
        int roadLayer = LayerMask.NameToLayer("Road");

        if (roadLayer == -1)
        {
            Debug.LogError("'Road'라는 이름의 레이어가 존재하지 않습니다. 먼저 레이어를 프로젝트 설정에서 추가하세요.");
            return;
        }

        GameObject[] allObjects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        foreach (GameObject obj in allObjects)
        {
            Collider col = obj.GetComponent<Collider>();
            if (col != null && col.sharedMaterial == roadMaterial)
            {
                obj.layer = roadLayer;
                updatedCount++;
            }
        }

        Debug.Log($"'Road' 물리 머티리얼을 사용하는 객체의 Layer를 'Road'로 변경한 수: {updatedCount}");
    }
}
