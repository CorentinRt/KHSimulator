using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Item
{
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

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.transform.parent.GetComponentInChildren<PlayerMove>() != null && other.transform.GetComponent<HitEntity>() == null)
            {
                other.transform.parent.GetComponent<EntityHealth>().IncreaseMaxHealth(ItemValue);
                GetItem();
            }
        }
    }
}
