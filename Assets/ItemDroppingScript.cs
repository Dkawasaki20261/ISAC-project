using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDroppingScript : MonoBehaviour
{
    public ItemDatabase itemdatabase;
    public static ItemDroppingScript Instance;
    private void Awake() 
    {
        Instance = this;
    }
    public bool DropItem(ItemDatabase.Itemname id, float transformX, float transformY, float transformZ)
    {
        var data = itemdatabase.GetItemData(id);
        var obj = Instantiate(data.prefab)as GameObject;
        obj.name = data.prefab.name;
        obj.transform.localPosition = new Vector3(transformX, transformY, transformZ);
        return true;
    }
}
