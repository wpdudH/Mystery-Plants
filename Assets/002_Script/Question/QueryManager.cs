using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueryManager : MonoBehaviour
{
    public List<Query> queryPool;
    public Text queryText;
    public Transform choicesContainer;
    public GameObject choiceButtonPrefab;
    public Button startButton;

    private int currentQueryIndex = 0;
    private List<Query> selectedQuerys = new List<Query>();
    private bool isQueryActive = false;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartQuiz);
        queryText.gameObject.SetActive(false);
        choicesContainer.gameObject.SetActive(false);
    }

    void StartQuiz()
    {
        startButton.gameObject.SetActive(false);
        queryText.gameObject.SetActive(true);
        choicesContainer.gameObject.SetActive(true);

        InitializeQuery();
        DisplayNextQuery();
        isQueryActive = true;
    }

    void InitializeQuery()
    {
        queryPool.Shuffle();
        selectedQuerys = queryPool.GetRange(0, Mathf.Min(7, queryPool.Count));
    }

    void DisplayNextQuery()
    {
        if(!isQueryActive)
        {
            return;
        }

        if(currentQueryIndex >= selectedQuerys.Count)
        {
            Debug.Log("질의 종료");
            GameManager.Instance.LoadScene("SampleScene");
            return;
        }

        Query currentQuery = selectedQuerys[currentQueryIndex];
        queryText.text = currentQuery.questionText;

        foreach(Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var choice in currentQuery.choices)
        {
            GameObject choiceButton = Instantiate(choiceButtonPrefab, choicesContainer);
            choiceButton.GetComponentInChildren<Text>().text = choice.choiceText;
            choiceButton.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelected(choice));
        }
    }

    void OnChoiceSelected(Query.Choice selectedChoice)
    {
        GameManager.Instance.ApplyTendencyChanges(selectedChoice.GetTendencyChange());
        currentQueryIndex++;
        DisplayNextQuery();
    }
}
