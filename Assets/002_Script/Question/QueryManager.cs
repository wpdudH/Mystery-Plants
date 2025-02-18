using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Query;

public class QueryManager : MonoBehaviour
{
    public List<Query> queryTwoAnsPool;
    public List<Query> queryFourAnsPool;
    public int queryCount;
    public Transform queryPrefab;
    public Transform choicesContainer;
    public GameObject choiceButtonPrefab;

    private int currentQueryIndex = 0;
    private List<Query> selectedQuerys = new List<Query>();
    private bool isQueryActive = false;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnQueryStart += StartQuiz;
        queryPrefab.gameObject.SetActive(false);
        choicesContainer.gameObject.SetActive(false);
    }

    void StartQuiz()
    {
        queryPrefab.gameObject.SetActive(true);
        choicesContainer.gameObject.SetActive(true);

        InitializeQuery();
        isQueryActive = true;
        DisplayNextQuery();
    }

    void AdjustLayout(int choiceCount)
    {
        GridLayoutGroup gridLayout = choicesContainer.GetComponent<GridLayoutGroup>();

        if(choiceCount == 2)
        {
            gridLayout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            gridLayout.padding.bottom = 150;
            gridLayout.constraintCount = 1;
        }
        else if(choiceCount == 4)
        {
            gridLayout.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            gridLayout.padding.bottom = 50;
            gridLayout.constraintCount = 2;
        }
    }

    void InitializeQuery()
    {
        queryTwoAnsPool.Shuffle();
        queryFourAnsPool.Shuffle();
    }

    void DisplayNextQuery()
    {
        if(!isQueryActive)
        {
            return;
        }

        if(currentQueryIndex >= queryCount)
        {
            Debug.Log("질의 종료");
            GameManager.Instance.EnableActEvent();
            GameManager.Instance.LoadScene("SampleScene");
            return;
        }

        Query currentQuery =  ScriptableObject.CreateInstance<Query>();

        if ((currentQueryIndex + 1) % 2 == 0)
        {
            currentQuery = queryTwoAnsPool[currentQueryIndex];
        }
        else
        {
            currentQuery = queryFourAnsPool[currentQueryIndex];
        }

        queryPrefab.GetComponentInChildren<Text>().text = currentQuery.questionText;

        foreach(Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }

        AdjustLayout(currentQuery.choices.Count);

        foreach (var choice in currentQuery.choices)
        { 
            GameObject choiceButton = Instantiate(choiceButtonPrefab, choicesContainer);
            choiceButton.GetComponentInChildren<Text>().text = choice.choiceText;

            Query.Choice capturedChoice = choice;
            choiceButton.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelected(capturedChoice));
        }
    }

    void OnChoiceSelected(Query.Choice selectedChoice)
    {
        GameManager.Instance.ApplyTendencyChanges(selectedChoice.GetTendencyChange());
        currentQueryIndex++;
        DisplayNextQuery();
    }
}
