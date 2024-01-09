using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGold : MonoBehaviour
{
    [SerializeField] private int _startGoldAmount;

    public event Action<int> OnGoldUpdate;
    public int CurrentGold { get; private set; }


    public void IncreaseGold(int value)
    {
        CurrentGold += value;
        OnGoldUpdate?.Invoke(CurrentGold);
    }
    public void DecreaseGold(int value)
    {
        CurrentGold -= value;
        if(CurrentGold < 0)
        {
            CurrentGold = 0;
        }
        OnGoldUpdate?.Invoke(CurrentGold);
    }
    
    private void Awake()
    {
        CurrentGold = _startGoldAmount;
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
