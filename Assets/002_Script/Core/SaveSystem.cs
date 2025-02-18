using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/flower_save.json";
    // Start is called before the first frame update
    public static void SaveDiscoveredFlowers(Dictionary<string, bool> discoveredFlowers)
    {
        Dictionary<string, bool> saveData = new Dictionary<string, bool>();
        saveData = discoveredFlowers;

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("���� �Ϸ�");
     }

    public static Dictionary<string, bool> LoadDiscoveredFlowers()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            Dictionary<string, bool> saveData = JsonUtility.FromJson<Dictionary<string, bool>>(json);
            Debug.Log($"�� �߰� ������ �ҷ���: {savePath}");
            return saveData;
        }
        else
        {
            Debug.Log("����� �� ������ ����, ���� �����մϴ�.");
            return new Dictionary<string, bool>(); // ���ο� �� ��ųʸ� ��ȯ
        }
    }
}
