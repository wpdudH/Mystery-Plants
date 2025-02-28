using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance { get; private set; }
    public EnvironmentType currentEnvironment;
    public Dictionary<EnvironmentType, string> environmentScenes = new Dictionary<EnvironmentType, string>()
    {
        { EnvironmentType.WrithingEarth, "WrithingEarthScene" },
        { EnvironmentType.TealWaveCradle, "AzureWaveScene" },
        { EnvironmentType.MovablesOfSky, "StarlitGardenScene" },
        { EnvironmentType.EdgeOfMeteor, "MeteorEdgeScene" },
        { EnvironmentType.WitchsBackyard, "WitchsBackyardScene" }
    };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetEnvironment(EnvironmentType environment)
    {
        currentEnvironment = environment;
        Debug.Log($"현재 환경 설정: {environment}");
    }

    public void LoadEnvironmentScene()
    {
        if (environmentScenes.ContainsKey(currentEnvironment))
        {
            string sceneName = environmentScenes[currentEnvironment];
            GameManager.Instance.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("유효하지 않은 환경입니다.");
        }
    }
}