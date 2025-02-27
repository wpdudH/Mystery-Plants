using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "NewResource", menuName = "Game")]
public class Resource : ScriptableObject
{

    public string resourceName;
    public ResourceType resourceType;
    public Sprite resourceImage;
    public int growthRate;
}
