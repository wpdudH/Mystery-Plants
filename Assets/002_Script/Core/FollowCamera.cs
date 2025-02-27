using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // 플레이어 캐릭터 참조
    public float height = 10f; // 카메라 높이
    public float distance = 7f; // 플레이어와의 거리
    public float angle = 25f; // 내려다보는 각도

    void LateUpdate()
    {
        if (player == null) return;

        // 카메라 위치 설정
        Vector3 offset = new Vector3(0, height, -distance);
        Quaternion rotation = Quaternion.Euler(angle, 0, 0);
        Vector3 targetPosition = player.position + rotation * offset;

        transform.position = targetPosition;
        transform.LookAt(player.position);
    }
}
