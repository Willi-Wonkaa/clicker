using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SlotScript : MonoBehaviour
{
    [SerializeField] public InventoryManager inventory_manager;
    public DiggingItem digging_item;
    public Automation automation;

    private Image icon;
    private TMP_Text count_UI;
    public ItemScriptableObject stored_item;
    public bool is_allow_to_craft;

    public int craft_item_len;
    public int item_count;

    private bool temp_bool;
    void Start()
    {
        inventory_manager = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
        icon = transform.GetChild(1).GetComponent<Image>();
        count_UI = transform.GetChild(2).GetComponent<TMP_Text>();

        icon.sprite = stored_item.icon;
        craft_item_len = stored_item.craft_item.Count;

        is_allow_to_craft = stored_item.is_allow_to_create;
    }

    void Update()
    {
        count_UI.text = item_count.ToString();
    }

    public void CraftItem()
    {
        if (stored_item.is_can_craft && is_allow_to_craft)
        {
            if (IsCanCraft())
            {
                for (int i = 0; i < craft_item_len; ++i)
                {
                    inventory_manager.MinusItem(stored_item.craft_item[i], stored_item.craft_count[i]);
                }

                inventory_manager.PlusItem(stored_item, stored_item.getting_count);
                SpecialThinks();
            }
        }
    }

    public bool IsCanCraft()
    {
        for (int i = 0; i < craft_item_len; ++i)
        {
            Debug.Log(stored_item.craft_item[i].item_name + stored_item.craft_count[i]);
            temp_bool = inventory_manager.ItemCheker(stored_item.craft_item[i], stored_item.craft_count[i]);
            Debug.Log(temp_bool);
            if (temp_bool == false)
            {
                return false;
            }
            
        }
        Debug.Log("IsCanCraft = true");
        return true;
    }



    public void SpecialThinks()
    {
        if (stored_item.is_tech == IsTech.Yes)
        {
            foreach (var item in stored_item.item_to_tech.opens_items_to_create)
            {
                foreach (var slot in inventory_manager.slots)
                {
                    if (slot.stored_item == item)
                    {
                        slot.is_allow_to_craft = true;
                        break;
                    }
                }
            }
            if (stored_item.item_to_tech.opens_items_to_spawn.Count > 0)
            {
                digging_item = GameObject.FindGameObjectWithTag(stored_item.item_to_tech.location_for_spawn_items_tag).GetComponent<DiggingItem>();

                if (digging_item.current_power < stored_item.item_to_tech.power)
                {
                    digging_item.current_power = stored_item.item_to_tech.power;
                }
                foreach (var item in stored_item.item_to_tech.opens_items_to_spawn)
                {
                    digging_item.items_list.Add(item);
                }

                if (digging_item.is_scene_active == false)
                {
                    digging_item.SceneStart();
                }
            }
        }
        if (stored_item.is_tool == IsTool.Yes)
        {
            if (stored_item.item_to_tool.opens_items_to_spawn.Count > 0)
            {

                digging_item = GameObject.FindGameObjectWithTag(stored_item.item_to_tool.location_for_spawn_items_tag).GetComponent<DiggingItem>();
                
                if (digging_item.current_power < stored_item.item_to_tool.power)
                {
                    digging_item.current_power = stored_item.item_to_tool.power;
                }

                foreach (var item in stored_item.item_to_tool.opens_items_to_spawn)
                {
                    digging_item.items_list.Add(item);
                }

                if (digging_item.is_scene_active == false)
                {
                    digging_item.SceneStart();
                }
            }
        }
        if (stored_item.is_automation == IsAutomation.Yes)
        {
            stored_item.item_to_automation.automation.is_automation_avalable = true;
        }
    }
    
}
