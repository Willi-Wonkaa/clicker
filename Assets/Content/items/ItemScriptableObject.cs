using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IsTech { Yes, No }
public enum IsTool { Yes, No }
public enum IsAutomation { Yes, No }
public class ItemScriptableObject : ScriptableObject
{
    public ToolType type;
    public IsTech is_tech = IsTech.No; 
    public IsTool is_tool = IsTool.No; 
    public IsAutomation is_automation = IsAutomation.No;
    public int digging_lvl;
    public float digging_time;

    public Sprite icon;
    public string item_name;
    public bool is_can_spawn = false;
    public ItemScriptableObject loot_item;

    public bool is_can_craft = true;
    public List<ItemScriptableObject> craft_item;
    public List<int> craft_count;
    public int getting_count = 1;


    public bool is_allow_to_spawn = false;
    public bool is_allow_to_create = false;

    public TechScriptableObject item_to_tech;
    public ToolScriptableObject item_to_tool;
    public AutomationScriptableObject item_to_automation;

}
