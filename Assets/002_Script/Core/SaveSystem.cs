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
        Debug.Log("저장 완료");
     }

    public static Dictionary<string, bool> LoadDiscoveredFlowers()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            Dictionary<string, bool> saveData = JsonUtility.FromJson<Dictionary<string, bool>>(json);
            Debug.Log($"꽃 발견 데이터 불러옴: {savePath}");
            return saveData;
        }
        else
        {
            Debug.Log("저장된 꽃 데이터 없음, 새로 생성합니다.");
            return new Dictionary<string, bool>(); // 새로운 빈 딕셔너리 반환
        }
    }
}
