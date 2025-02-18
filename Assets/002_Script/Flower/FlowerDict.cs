using System.Collections.Generic;
using UnityEngine;

public class FlowerDict : MonoBehaviour, IDictObserver
{
    public static FlowerDict Instance { get; private set; }
    // �߰��� �� ����Ʈ 
    private Dictionary<string, bool> discoveredFlowers = new Dictionary<string, bool>();

    public FlowerDataBase flowerDatabase;

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

    private void Start()
    {
        LoadDiscoveredFlowers();
    }

    private void LoadDiscoveredFlowers()
    {
        discoveredFlowers = SaveSystem.LoadDiscoveredFlowers();

        foreach (var flower in flowerDatabase.flowers)
        {
            if (discoveredFlowers.ContainsKey(flower.flowerName))
            {
                flower.isDiscovered = discoveredFlowers[flower.flowerName]; // ����� �� ����
            }
        }
    }

    public void OnFlowerDiscovered(EnvironmentType environment, FlowerData flower)
    {
        flower.isDiscovered = true;
        discoveredFlowers[flower.flowerName] = true;
        SaveSystem.SaveDiscoveredFlowers(discoveredFlowers);

        flowerDatabase.UpdateFlowerDictionary(flower);
    }
}
