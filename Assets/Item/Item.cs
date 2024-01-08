using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Item : MonoBehaviour
{
    public Item(ItemType itemType)
    {
        
    }
    public enum ItemType
    {
        HealthPotion,
        PowerUp,
        Gold
    }

    // Fields

    private ItemType _currentType;


    // Properties
    public ItemType CurrentType { get => _currentType; set => _currentType = value; }



    // Methods
    public abstract void GetItem();
    public abstract void DestroyItem();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
