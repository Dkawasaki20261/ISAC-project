using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public GameObject prefab;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public ItemData(ItemDatabase.Itemname id, string title, string description, Dictionary<string, int> stats)
    {
        this.id = (int)id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Own Sprites/Items/" + title);
        this.prefab = Resources.Load<GameObject>("Own Prefabs/" + title);
        this.stats = stats;
    }
    public ItemData(ItemData item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = Resources.Load<Sprite>("Own Sprites/Items/" + item.title);
        this.prefab = Resources.Load<GameObject>("Own Prefabs/" + item.title);
        this.stats = item.stats;
    }
}
