using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Dictionary<string, int> playerTendency = new Dictionary<string, int>()
    {
        {"Violent", 0},
        {"Intelligent", 0},
        {"Sweet", 0},
        {"Madness", 0}
    };

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ApplyTendencyChanges(Dictionary<string, int> tendencyChanges)
    {
        foreach (var tendency in tendencyChanges)
        {
            if(playerTendency.ContainsKey(tendency.Key))
            {
                playerTendency[tendency.Key] += tendency.Value;
                Debug.Log($"스탯 변경: {tendency.Key} +{tendency.Value} → 현재 값: {playerTendency[tendency.Key]}");
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
