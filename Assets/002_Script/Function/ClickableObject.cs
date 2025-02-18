using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public ClickEvent eventName;

    private void OnMouseDown()
    {
        GameManager.Instance.StartQuery(eventName);
    }
}
