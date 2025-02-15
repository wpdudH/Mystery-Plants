using UnityEngine;
using UnityEngine.UI;

public class ObjectClickUI : MonoBehaviour
{
    public GameObject uiPrefab;
    private GameObject spawnedUI;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("클릭한 오브젝트: " + hit.transform.name);

                if (spawnedUI == null)
                {
                    spawnedUI = Instantiate(uiPrefab);
                    spawnedUI.transform.SetParent(GameObject.Find("Canvas").transform, false);
                }
                else
                {
                    Destroy(spawnedUI);
                }
            }
        }
    }
}
