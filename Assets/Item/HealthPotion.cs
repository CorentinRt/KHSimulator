using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private int _healthValue;

    public HealthPotion(ItemType itemType) : base(itemType)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.transform.parent.GetComponentInChildren<PlayerMove>() != null && other.transform.GetComponent<HitEntity>() == null)
            {
                other.transform.parent.GetComponentInChildren<EntityHealth>().IncreaseHealth(_healthValue);
            }
        }
    }
}
