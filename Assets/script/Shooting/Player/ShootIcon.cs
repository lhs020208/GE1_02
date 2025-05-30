
using UnityEditor;
using UnityEngine;

public class ShootIcon : MonoBehaviour
{
    public GameObject player;
    public PlayerStatusManager playerStatusManager;
    public Material material;

    // 경로는 프로젝트 기준 경로 (Assets부터 시작)
    private static readonly string[] materialPaths = new string[]
    {
        "Assets/Material/Shoot0.mat",
        "Assets/Material/Shoot1.mat",
        "Assets/Material/Shoot2.mat"
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        playerStatusManager = player.GetComponent<PlayerStatusManager>();
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        int type = playerStatusManager.ShootType;
        if (type >= 0 && type < materialPaths.Length)
        {
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(materialPaths[type]);
            if (mat != null)
                GetComponent<Renderer>().material = mat;
        }
    }
}
