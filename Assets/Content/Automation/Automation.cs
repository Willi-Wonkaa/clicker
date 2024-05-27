using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automation : MonoBehaviour
{
    public AutomationScriptableObject contain_automation;

    public InventoryManager inventory_manager;
    private List<ItemScriptableObject> items_list;
    public ItemScriptableObject item;


    private GameObject digging_item_image;
    private Image procces_indicator;
    private float procces_progress = 1f;

    private float start_digging_time;
    private int random_number;
    private bool is_digging_active = false;
    public bool is_automation_avalable = false;


    void Start()
    {
        contain_automation.automation = this.GetComponent<Automation>();
        items_list = contain_automation.automated_items;
        inventory_manager = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
        digging_item_image = transform.GetChild(1).gameObject;
        procces_indicator = transform.GetChild(3).GetComponent<Image>();

        NextItem();
    }

    public void Update()
    {
        if (is_automation_avalable)
        {
            FullDiggingProcess();
        }
    }


    public void NextItem()
    {
        random_number = UnityEngine.Random.Range(0, items_list.Count);
        item = items_list[random_number];
        digging_item_image.GetComponent<Image>().sprite = item.icon;
    }

    public void FullDiggingProcess()
    {
        // предпологаем что предмет который мы добываем уже есть
        if (is_digging_active == false)
        {
            start_digging_time = Time.time;
            is_digging_active = true;
        }

        procces_progress = item.digging_time - (Time.time - start_digging_time);
        if (procces_progress > 0)
        {
            procces_indicator.fillAmount = procces_progress;
        }
        else
        {
            is_digging_active = false;
            procces_progress = 1f;
            procces_indicator.fillAmount = procces_progress;
            inventory_manager.AddSingleItem(item.loot_item);
            NextItem();
        }

    }
}