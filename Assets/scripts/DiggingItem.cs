using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiggingItem : MonoBehaviour
{
    public InventoryManager inventory_manager;

    public List<ItemScriptableObject> items_list;
    public List<int> chance_to_spawn_list;

    public int current_digging_lvl;

    public ItemScriptableObject item;

    private GameObject digging_item_image;
    private Image procces_indicator;
    private float procces_progress = 1f;

    private float start_digging_time;
    private bool is_digging_active = false;
    private int random_number;
    public float current_power = 1f;

    public GameObject this_location;
    public CanvasGroup this_canvas_group;
    public bool is_scene_active;


    void Start()
    {
        inventory_manager = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryManager>();
        digging_item_image = transform.GetChild(1).gameObject;
        procces_indicator = transform.GetChild(3).GetComponent<Image>();

        if (items_list.Count > 0)
        {
            this_canvas_group.alpha = 1f;
            is_scene_active = true;
            NextItem();
        } else
        {
            is_scene_active = false;
            this_canvas_group.alpha = 0f;
        }



    }

    void Update()
    {
        if (is_scene_active)
        {
            if (is_digging_active)
            {
                Digging();
            }
        }
    }


    void Digging()
    {

        procces_progress = (item.digging_time / current_power) - (Time.time - start_digging_time);
        if (procces_progress > 0)
        {
            procces_indicator.fillAmount = procces_progress;
        } else
        {
            DigginEnd();
        }

    }

    public void DiggingStart()
    {
        if (is_digging_active == false)
        {
            is_digging_active = true;
            start_digging_time = Time.time;
        }
    }

    public void DigginEnd()
    {
        is_digging_active = false;
        procces_progress = 1f;
        procces_indicator.fillAmount = procces_progress;
        inventory_manager.AddSingleItem(item.loot_item);
        NextItem();

    }


    public void NextItem()
    {
        random_number = UnityEngine.Random.Range(0, items_list.Count);
        Debug.Log(items_list.Count);
        Debug.Log(random_number);
        item = items_list[random_number];
        digging_item_image.GetComponent<Image>().sprite = item.icon;
    }

    public void SceneStart()
    {
        this_canvas_group.alpha = 1f;
        is_scene_active = true;
        NextItem();


    }

}
