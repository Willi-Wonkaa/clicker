using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TechSlot : MonoBehaviour
{
    public TechScriptableObject stored_tech;

    private Image icon;

    public bool is_active;

    void Start()
    {
        icon = transform.GetChild(1).GetComponent<Image>();
        icon.sprite = stored_tech.tech_to_item.icon;

    }
}
