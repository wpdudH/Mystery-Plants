using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public EnvironmentType selectedEnvironment;
    //public List<EnvironmentData> environments;

    private int maxScore = 0;

    //Clickable Object Event Action
    public event Action OnQueryStart;
    public event Action OnDictionaryShow;
    //Clickable Object�� �̺�Ʈ �߻� ���� ����
    private bool CanActEvent = true;

    private Dictionary<string, int> playerTendency = new Dictionary<string, int>()
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

    public void SetSelectedEnvironment(EnvironmentType environment)
    {
        selectedEnvironment = environment;
        Debug.Log("���õ� ȯ��: " + environment);
    }

    public void ApplyTendencyChanges(Dictionary<string, int> tendencyChanges)
    {
        foreach (var tendency in tendencyChanges)
        {
            if(playerTendency.ContainsKey(tendency.Key))
            {
                playerTendency[tendency.Key] += tendency.Value;
                Debug.Log($"���� ����: {tendency.Key} +{tendency.Value} �� ���� ��: {playerTendency[tendency.Key]}");
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ȯ�� ���� �޼���
    public void DetermineEnvironment()
    {
        maxScore = 0;

        List<string> topTendencies = new List<string>();

        foreach (var tendency in  playerTendency)
        {
            if (tendency.Value > maxScore)
            {
                maxScore = tendency.Value;
                topTendencies.Clear();
                topTendencies.Add(tendency.Key);
            }
            else if(tendency.Value == maxScore)
            {
                topTendencies.Add(tendency.Key);
            }
        }
    }

    public int GetMaxTendencyScore()
    {
        return maxScore;
    }

    public void SetMaxTendencyScore(int score)
    {
        maxScore = score;
    }

    // Ŭ���Ǿ��� �� ���� �Լ�.
    public void StartQuery(ClickEvent eventName)
    {
        if (!CanActEvent) return;

        switch(eventName)
        {
            case ClickEvent.Query:
                OnQueryStart?.Invoke();
                CanActEvent = false;
                break;
            case ClickEvent.Dictionary:
                OnDictionaryShow?.Invoke();
                CanActEvent = false;
                break;
        }
    }

    public void EnableActEvent()
    {
        CanActEvent = true;
    }
}
