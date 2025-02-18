using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    // UI ������
    public GameObject flowerDict;
    // public GameObject gameHUD;
    //public GameObject flowerResultPrefab;

    private Stack<GameObject> activateUIs = new Stack<GameObject>();

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

        flowerDict.SetActive(false);
    }

    private void Start()
    {
        GameManager.Instance.OnDictionaryShow += ShowFlowerDict;
    }

    private bool CanOpenNewUI()
    {
        return activateUIs.Count == 0;
    }

    public void ShowFlowerDict()
    {
        if (!CanOpenNewUI())
        {
            return;
        }

        flowerDict.SetActive(true);
        activateUIs.Push(flowerDict);
    }

    //public void ShowFlowerResult()
    //{
    //    if (!CanOpenNewUI()) return;

    //    GameObject ui = Instantiate(flowerResultPrefab);
    //    ui.SetActive(true);
    //    activateUIs.Push(ui);
    //}

    public void HideFlowerDict()
    {
        flowerDict.SetActive(false);
        activateUIs.Pop();
        GameManager.Instance.EnableActEvent();
    }

    //public void HideFlowerResult()
    //{
    //    CloseSpecificUI(flowerResultPrefab);
    //}

    public void CloseSpecificUI(GameObject uiPrefab)
    {
        if (activateUIs.Count > 0 && activateUIs.Peek().name.Contains(uiPrefab.name))
        {
            GameObject topUI = activateUIs.Pop();
            topUI.SetActive(false);
            Destroy(topUI);
        }
        else
        {
            Debug.Log($"���� top�� ��ġ�� UI�� {uiPrefab} ���� ������ UI �� �ƴմϴ�.");
        }
    }
}
