using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "FlowerDatabase", menuName = "Game/FlowerDatabase")]
public class FlowerDataBase : ScriptableObject
{
    public List<FlowerData> flowers; // 전체 꽃 데이터

    private Dictionary<EnvironmentType, Dictionary<string, FlowerData>> flowerByEnvironment = new Dictionary<EnvironmentType, Dictionary<string, FlowerData>>();

    private void OnEnable()
    {
        BuildFlowerDictionary();
    }

    private void BuildFlowerDictionary()
    {
        flowerByEnvironment.Clear();

        foreach (var flower in flowers)
        {
            if (!flowerByEnvironment.ContainsKey(flower.env))
            {
                flowerByEnvironment[flower.env] = new Dictionary<string, FlowerData>();
            }
            flowerByEnvironment[flower.env][flower.flowerName] = flower;
        }
    }

    public void UpdateFlowerDictionary(FlowerData flower)
    {
        flowerByEnvironment[flower.env][flower.flowerName] = flower;
    }

    public List<FlowerData> GetFlowersByEnvironment(EnvironmentType environment)
    {
        return flowerByEnvironment[environment].Values.ToList();
    }
}
