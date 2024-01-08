using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class EntityHealth : MonoBehaviour
{

    [SerializeField] int _maxHealth;
    public event Action<int> OnHealthUpdate;
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    private void Start()
    {

    }

    // Methods

    public void DecreaseHealth(int value)
    {
        CurrentHealth -= value;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, _maxHealth);
        OnHealthUpdate?.Invoke(CurrentHealth);
    }
    public void IncreaseHealth(int value)
    {
        CurrentHealth += value;
        Debug.Log("increase");
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, _maxHealth);
        OnHealthUpdate?.Invoke(CurrentHealth);
    }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }



}
