using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AutomationSlot : MonoBehaviour
{
    public AutomationScriptableObject stored_automatoin;
    public GameObject automation_GO;

    private Image icon;

    public bool is_active;
    void Start()
    {
        icon = transform.GetChild(1).GetComponent<Image>();
        automation_GO.SetActive(false);

        icon.sprite = stored_automatoin.automation_to_item.icon;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
