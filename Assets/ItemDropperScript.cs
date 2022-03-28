using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropperScript : MonoBehaviour
{
    public ItemDatabase.Itemname droppingitemname;
    public ItemDatabase.Toolname toolname;
    private float randomDroppingX;
    private float randomDroppingZ;
    // Start is called before the first frame update
    void Start()
    {
        //ItemDroppingScript.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == toolname.ToString())
        {
            
            while(true)
            {
                randomDroppingX = Random.Range(-1.5f, 1.5f);
                if(randomDroppingX <= -1.1f || randomDroppingX >= 1.1f) //*When it's good number
                {
                    break;
                }
            }
            while(true)
            {
                randomDroppingZ = Random.Range(-1.5f, 1.5f);
                if(randomDroppingZ <= -1.1f || randomDroppingZ >= 1.1f) //*When it's good number
                {
                    break;
                }
            }
            ItemDroppingScript.Instance.DropItem(droppingitemname, transform.position.x + randomDroppingX, transform.position.y + 1.5f, transform.position.z + randomDroppingZ);
        }
    }
}
