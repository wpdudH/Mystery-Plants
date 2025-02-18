using UnityEngine;

[CreateAssetMenu(fileName = "NewFlower", menuName = "Game/FlowerData")]
public class FlowerData : ScriptableObject
{
    public string flowerName;             // 꽃 이름
    public EnvironmentType env;           // 서식지
    public FlowerRarity rarity;           // 희귀도
    [TextArea] public string description; // 설명
    public Sprite flowerImage;            // 꽃 이미지
    public Sprite flowerImageFrame;       // 프레임이 있는 꽃 이미지
    public bool isDiscovered = false;     // 발견 되었는지
}
