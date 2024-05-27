using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TechScriptableObject : ScriptableObject
{
    public ItemScriptableObject tech_to_item;

    public bool is_research = false;

    public float power = 1f;

    public string location_for_spawn_items_tag;
    public List<ItemScriptableObject> opens_items_to_spawn;
    public List<ItemScriptableObject> opens_items_to_create;


    public void OpenItemsToSpawn()
    {
        foreach (var item in opens_items_to_spawn)
        {
            item.is_allow_to_spawn = true;
        }
    }

    public void OpenItemsToCreate()
    {
        foreach (var item in opens_items_to_create)
        {
            item.is_allow_to_create = true;
        }
    }


}

