using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed = 5f;   // 이동 속도
    public Camera mainCamera;      // 카메라 참조
    public LayerMask groundLayer;  // 이동 가능한 레이어 (바닥)
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position; // 시작 위치를 현재 위치로 설정
    }

    void Update()
    {
        HandleMouseClick();
        MoveToTarget();
    }

    void HandleMouseClick()
    {
        if (Input.GetMouseButtonDown(0)) // 좌클릭
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 땅(groundLayer)만 감지하도록 레이어 마스크 적용
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                targetPosition = hit.point;
                isMoving = true;
            }
        }
    }

    void MoveToTarget()
    {
        if (!isMoving) return;

        // 이동할 때 항상 일정한 Y 높이를 유지
        float characterHeight = 2.34f; // 캐릭터의 적절한 높이 (설정에 따라 조정)
        Vector3 targetPosFixed = new Vector3(targetPosition.x, characterHeight, targetPosition.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosFixed, moveSpeed * Time.deltaTime);

        // 이동 중이면 캐릭터 방향을 회전
        Vector3 direction = targetPosFixed - transform.position;
        direction.y = 0; // 2D 캐릭터이므로 Y축 회전 방지
        if (direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        // 목표 위치에 도달하면 이동 종료
        if (Vector3.Distance(transform.position, targetPosFixed) < 0.1f)
        {
            isMoving = false;
        }
    }
}
