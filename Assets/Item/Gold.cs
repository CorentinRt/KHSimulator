using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Item
{
    public Gold(ItemType itemType) : base(itemType)
    {
        CurrentType = itemType;
    }

    public override void GetItem()
    {
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
