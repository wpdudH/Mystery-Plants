using System.Collections.Generic;
using UnityEngine;
using static Query;

[CreateAssetMenu(fileName = "NewQuery", menuName = "Game/QueryData")]
public class Query : ScriptableObject
{
    // ���� ����
    [TextArea(2, 5)]
    public string       questionText;

    // ���� ��ȭ�� ��Ÿ��.
    [System.Serializable]
    public class TendencyChange
    {
        public string   tendencyName;
        public int      value;
    }

    // ������ + ���� ��ȭ ����
    [System.Serializable]
    public class Choice
    {
        public string                choiceText;
        public List<TendencyChange>  TendencyChanges;

        // ���ÿ� ���� ��� ��ȯ
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
