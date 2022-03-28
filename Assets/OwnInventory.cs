using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnInventory : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();
    public ItemDatabase itemDataBase;
    //If the item exists in the slot
    public bool CheckExistItem(int index) 
    {
        if(items.Count>index)
        {
            if(items[index] != null)
            {
                return true;
            }
        }
        return false;
    }
    //Get item's data
    public InventoryItem GetItem(int index)
    {
        return items[index];
    }
    public bool AddItem(int id, int count)
    {
        var founditem= items.Find(n=> n.Data.id == id);
        if(founditem != null)
        {
            //If there were already made
            founditem.NumOfItem += count;
            return true;
        }
        else
        {
            // and not
            var data = itemDataBase.GetItemData(id);
            var newitem = new InventoryItem();
            //add item imformation
            newitem.Data = data;
            newitem.NumOfItem = count;
            items.Add(newitem);
            return true;
        }
        
    }
    public bool AddItemFromName(string name, int count)
    {
        var ItemId = itemDataBase.GetItemIdFromName(name);
        Debug.Log(ItemId);
        return AddItem(ItemId, count);
    }
}
