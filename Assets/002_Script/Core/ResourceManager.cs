using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    private Dictionary<Resource, int> resources = new Dictionary<Resource, int>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ObtainResource(Resource resource, int count)
    { 
        if(resources.ContainsKey(resource))
        {
            resources[resource] += count;
        }
        else
        {
            Debug.Log($"Manager don't have {resource}");
        }
    }

    public void SubtractResource(Resource resource, int count)
    {
        if (resources.ContainsKey((resource)))
        {
            while(count == 0)
            {
                if (resources[resource] > 0)
                {
                    resources[resource] -= 1;
                    count--;
                }
                else
                {
                    break;
                }
            }
        }
        else
        {
            Debug.Log($"Manager don't have {resource}");
        }
    }

    public void UseResource(Resource resource)
    {
        switch(resource.resourceType)
        {
            case ResourceType.Upgrade:
                break;
            case ResourceType.HiddenItem:
                break;
            case ResourceType.TimeBoost:
                break;
        }
    }
}
