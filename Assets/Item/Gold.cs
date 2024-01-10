using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    public override void GetItem(GameObject target)
    {
        target.transform.parent.GetComponent<EntityGold>().IncreaseGold(ItemValue);

        DestroyItem();
    }
    public override void DestroyItem()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
