using UnityEngine;

[CreateAssetMenu(fileName = "NewFlower", menuName = "Game/FlowerData")]
public class FlowerData : ScriptableObject
{
    public string flowerName;             // �� �̸�
    public EnvironmentType env;           // ������
    public FlowerRarity rarity;           // ��͵�
    [TextArea] public string description; // ����
    public Sprite flowerImage;            // �� �̹���
    public Sprite flowerImageFrame;       // �������� �ִ� �� �̹���
    public bool isDiscovered = false;     // �߰� �Ǿ�����
}
