using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingScript : MonoBehaviour
{
    public OwnInventory owninventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Collectable")
        {
            owninventory.AddItemFromName(other.name, 1);
            Destroy(other.gameObject);
        }
    }
}
