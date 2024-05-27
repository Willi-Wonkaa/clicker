using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
    public GameObject slot;
    public Sprite icon;
    public string item_name;
    public int id;
    public int item_count = 0;
    public TMP_Text count_UI;

    void Start()
    {
        count_UI.text = item_count.ToString();
    }
}
