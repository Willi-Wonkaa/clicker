using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public Transform inventory_T;
    public GameObject inventory_Go;
    public CanvasGroup inventory_canvas_group;
    public RectTransform inventory_RT;

    public GameObject tech_GO;
    public Transform tech_T;
    public CanvasGroup tech_canvas_group;
    public RectTransform tech_RT;

    public GameObject automation_GO;
    public Transform automation_T;
    public CanvasGroup automation_canvas_group;
    public RectTransform automation_RT;


    public GameObject tool_GO;
    public Transform tool_T;
    public CanvasGroup tool_canvas_group;
    public RectTransform tool_RT;


    public List<SlotScript> slots = new List<SlotScript>();
    private List<SlotScript> technologies = new List<SlotScript>();
    private List<SlotScript> automation = new List<SlotScript>();


    void Start()
    {

        InventoryOn();
        for (int i = 0; i < inventory_T.childCount; i++)
        {
            slots.Add(inventory_T.GetChild(i).GetComponent<SlotScript>());
        }
        for (int i = 0; i < tool_T.childCount; i++)
        {
            slots.Add(tool_T.GetChild(i).GetComponent<SlotScript>());
        }

        for (int i = 0; i < tech_T.childCount; i++)
        {
            technologies.Add(tech_T.GetChild(i).GetComponent<SlotScript>());
        }

        for (int i = 0; i < automation_T.childCount; i++)
        {
            automation.Add(automation_T.GetChild(i).GetComponent<SlotScript>());
        }

        /*
        foreach (var slot in slots)
        {
            Debug.Log("slot contain: " + slot.stored_item.item_name);
        }*/
    }



    /*
    public void InventoryOn()
    {
        inventory_canvas_group.alpha = 1f;
        tech_canvas_group.alpha = 0f;
        automation_canvas_group.alpha = 0f;
    }

    public void TechOn()
    {
        inventory_canvas_group.alpha = 0f;
        tech_canvas_group.alpha = 1f;
        automation_canvas_group.alpha = 0f;
    }

    public void AutomationOn()
    {
        inventory_canvas_group.alpha = 0f;
        tech_canvas_group.alpha = 0f;
        automation_canvas_group.alpha = 1f;
    }
    */

    public void InventoryOn()
    {
        inventory_RT.anchoredPosition = new Vector2(0, 0);
        tech_RT.anchoredPosition = new Vector2(10000, 0);
        automation_RT.anchoredPosition = new Vector2(10000, 0);
        tool_RT.anchoredPosition = new Vector2(10000, 0);
    }

    public void TechOn()
    {
        inventory_RT.anchoredPosition = new Vector2(10000, 0);
        tech_RT.anchoredPosition = new Vector2(0, 0);
        automation_RT.anchoredPosition = new Vector2(10000, 0);
        tool_RT.anchoredPosition = new Vector2(10000, 0);
    }

    public void AutomationOn()
    {
        inventory_RT.anchoredPosition = new Vector2(10000, 0);
        tech_RT.anchoredPosition = new Vector2(10000, 0);
        automation_RT.anchoredPosition = new Vector2(0, 0);
        tool_RT.anchoredPosition = new Vector2(10000, 0);
    }

    public void ToolOn()
    {
        inventory_RT.anchoredPosition = new Vector2(10000, 0);
        tech_RT.anchoredPosition = new Vector2(10000, 0);
        automation_RT.anchoredPosition = new Vector2(10000, 0);
        tool_RT.anchoredPosition = new Vector2(0, 0);
    }



    public void AddSingleItem(ItemScriptableObject item)
    {
        foreach (var slot in slots)
        {
            if (slot.stored_item == item)
            {
                slot.item_count++;
            }
        }
    }

    public void MinusItem(ItemScriptableObject item, int count)
    {
        foreach (var slot in slots)
        {
            if (slot.stored_item == item)
            {
                slot.item_count -= count;
            }
        }
    }
    public void PlusItem(ItemScriptableObject item, int count)
    {
        foreach (var slot in slots)
        {
            if (slot.stored_item == item)
            {
                slot.item_count += count;
            }
        }
    }

    public bool ItemCheker(ItemScriptableObject item, int count)
    {
        foreach (var slot in slots)
        {
            if (slot.stored_item == item)
            {
                if (slot.item_count >= count)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }
        return false;
    }


    public void GettingComponents()
    {

        inventory_canvas_group = inventory_Go.GetComponent<CanvasGroup>();
        tech_canvas_group = tech_GO.GetComponent<CanvasGroup>();
        automation_canvas_group = automation_GO.GetComponent<CanvasGroup>();
        tool_canvas_group = automation_GO.GetComponent<CanvasGroup>();


        inventory_RT = inventory_Go.GetComponent<RectTransform>();
        tech_RT = tech_GO.GetComponent<RectTransform>();
        automation_RT = automation_GO.GetComponent<RectTransform>();
        tool_RT = tool_GO.GetComponent<RectTransform>();
    }

}
