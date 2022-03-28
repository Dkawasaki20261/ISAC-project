using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemDatabase : MonoBehaviour
{
    public enum Itemname
    {
        Dirt, Rock, Wood
    }
    public enum Toolname
    {
        Pickaxe, Axe
    }
    public List<ItemData> items = new List<ItemData>();
    private void Awake() 
    {
        BuildDatabase();
    }

    void BuildDatabase()
    {
        //can create as many items we want to, separated by commas:
        items = new List<ItemData>()
        {
            new ItemData(Itemname.Dirt, "Dirt", "A dirt that feels like... sand.",
                new Dictionary<string, int>
                {
                    {"Material", 1}
                }),
                new ItemData(Itemname.Rock, "Rock", "A similar rock that is in Earth but red",
                new Dictionary<string, int>
                {
                    {"Material", 1}
                }),
                new ItemData(Itemname.Wood, "Wood", "A wood that you got from Mars wood... feels weird",
                new Dictionary<string, int>
                {
                    {"Material", 1}
                }
            )
        };
    }
    public ItemData GetItemData(int id)
    {
        var data = items.Find(n => n.id == id);
        return data;
    }
    public int GetItemIdFromName(string name){
        var id = items.Find(n=> n.title == name).id;
        return id;
    }
    public ItemData GetItemData(Itemname id)
    {
        return GetItemData((int)id);
    }

}
