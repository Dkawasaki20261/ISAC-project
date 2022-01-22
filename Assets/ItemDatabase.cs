using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake() 
    {
        BuildDatabase();
        Debug.Log("Activated");
    }

    void BuildDatabase()
    {
        //can create as many items we want to, separated by commas:
        items = new List<Item>(){new Item(0, "Dirt", "A dirt that feels like... sand.",
            new Dictionary<string, int>
            {
                {"Material", 1}
            //}),
            //new Item(1, "Log", "A log that you got from Mars wood... feels weird",
            //new Dictionary<string, int>
            //{
            //    {"Material", 1}
            })
        };
    }
}
