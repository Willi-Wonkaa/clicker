using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor.U2D.Aseprite;

public enum ToolType { Pickaxe, Shovel, Sword, Axe, Hoe, Arm, Bucket};

public class ToolScriptableObject : ScriptableObject
{
    public ItemScriptableObject tool_to_item;

    public ToolType type;
    public float power;
    public string item_name;
    public string location_for_spawn_items_tag;
    public List<ItemScriptableObject> opens_items_to_spawn;
    


}
