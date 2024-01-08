using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attack;

    public event Action OnStartAttack;

    [SerializeField] private BoxCollider _attackRange;

    // Methods


    // Start is called before the first frame update
    void Start()
    {
        _attack.action.started += StartAttack;
    }
    private void OnDestroy()
    {
        _attack.action.started -= StartAttack;
    }

    void StartAttack(InputAction.CallbackContext context)
    {
        OnStartAttack?.Invoke();
        _attackRange.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
