using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerDictUI : MonoBehaviour
{
    public Button wirthingEarthBTN;
    public Button tealWaveCardleBTN;
    public Button MovablesOfSkyBTN;
    public Button EdgeOfMeteorBTN;
    public Button WitchesBackyardBTN;

    public Transform flowerContainer;
    public GameObject flowerThumbnailPrefab;
    public Transform flowerDetailContainer;
    public GameObject flowerDetailPrefab;
    private Dictionary<FlowerData, GameObject> flowerEntries = new Dictionary<FlowerData, GameObject>();

    private EnvironmentType currentPage;

    // Start is called before the first frame update
    void Start()
    {
        wirthingEarthBTN.onClick.AddListener(() => ChangePage(EnvironmentType.WrithingEarth));
        tealWaveCardleBTN.onClick.AddListener(() => ChangePage(EnvironmentType.TealWaveCradle)); ;
        MovablesOfSkyBTN.onClick.AddListener(() => ChangePage(EnvironmentType.MovablesOfSky)); ;
        EdgeOfMeteorBTN.onClick.AddListener(() => ChangePage(EnvironmentType.EdgeOfMeteor)); ;
        WitchesBackyardBTN.onClick.AddListener(() => ChangePage(EnvironmentType.WitchsBackyard)); ;
        DisplayPage(EnvironmentType.WrithingEarth);
    }

    public void DisplayPage(EnvironmentType envrionment)
    {
        currentPage = envrionment;

        foreach(Transform child in flowerContainer)
        {
            Destroy(child);
        }
        foreach (Transform child in flowerDetailContainer)
        {
            Destroy(child);
        }

        List<FlowerData> flowers = FlowerDict.Instance.flowerDatabase.GetFlowersByEnvironment(envrionment);

       foreach(var flower in flowers)
       {
            GameObject flowerThumbnail = Instantiate(flowerThumbnailPrefab, flowerContainer);
            Image imageComponent = flowerThumbnail.GetComponent<Image>();
            Button buttonComponent = flowerThumbnail.GetComponent<Button>();

            if (flower.isDiscovered)
            {
                imageComponent.sprite = flower.flowerImage;
                buttonComponent.onClick.AddListener(() => DisplayFlowerDetails(flower, false));
            }
            else
            {
                imageComponent.sprite = null;
                buttonComponent.onClick.AddListener(() => DisplayFlowerDetails(flower, true));
            }
       }
    }

    private void DisplayFlowerDetails(FlowerData flower, bool isUnknown)
    {
        GameObject flowerDetail = Instantiate(flowerDetailPrefab, flowerDetailContainer);
        if (isUnknown)
        {
            string name = "²É¸í: ???";
            string rarity = "Èñ±Íµµ: ???";
            string habitat = "¼­½ÄÁö: ???";
            string description = "¾ÆÁ÷ ¹ß°ßµÇÁö ¾Ê¾Ò´Ù.";
            flowerDetail.GetComponent<FlowerDetailUI>().SetText(name, rarity, habitat, description);
        }
        else
        {
            string name = "²É¸í: " + flower.flowerName;
            string rarity = "Èñ±Íµµ: " + flower.rarity;
            string habitat = "¼­½ÄÁö: " + flower.env;
            string description = flower.description;
            flowerDetail.GetComponent<FlowerDetailUI>().SetText(name, rarity, habitat, description);
        }
    }

    public void ChangePage(EnvironmentType environment)
    {
        DisplayPage(environment);
    }
}
