using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerDetailUI : MonoBehaviour
{
    [SerializeField] private Text Name;
    [SerializeField] private Text Rarity;
    [SerializeField] private Text Env;
    [SerializeField] private Text Description;

    // Update is called once per frame
    public void SetText(string Name, string Rarity, string Env, string Description)
    {
        
    }
}
