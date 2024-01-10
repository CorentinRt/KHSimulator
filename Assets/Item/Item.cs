using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Item : MonoBehaviour
{
    public enum ItemType
    {
        HealthPotion,
        PowerUp,
        Gold
    }

    // Fields

    [SerializeField] private ItemType _currentType;

    [SerializeField] int _itemValue;

    // Properties
    public ItemType CurrentType { get => _currentType; set => _currentType = value; }
    public int ItemValue { get => _itemValue; set => _itemValue = value; }



    // Methods
    public abstract void GetItem(GameObject target);
    public abstract void DestroyItem();

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
                GetItem(other.gameObject);
            }
        }
    }
}
