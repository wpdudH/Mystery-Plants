using System.Collections.Generic;
using UnityEngine;
using static Query;

[CreateAssetMenu(fileName = "NewQuery", menuName = "Game/QueryData")]
public class Query : ScriptableObject
{
    // 질문 내용
    [TextArea(2, 5)]
    public string       questionText;

    // 성향 변화를 나타냄.
    [System.Serializable]
    public class TendencyChange
    {
        public string   tendencyName;
        public int      value;
    }

    // 선택지 + 성향 변화 저장
    [System.Serializable]
    public class Choice
    {
        public string                choiceText;
        public List<TendencyChange>  TendencyChanges;

        // 선택에 따른 결과 반환
        public Dictionary<string, int> GetTendencyChange()
        {
            Dictionary<string, int> TendencyDict = new Dictionary<string, int>();
            foreach (TendencyChange change in TendencyChanges)
            {
                TendencyDict[change.tendencyName] = change.value;
            }
            return TendencyDict;
        }
    }

    public List<Choice> choices = new List<Choice>();
}
