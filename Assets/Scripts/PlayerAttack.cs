using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attack;

    Coroutine _attackCooldown;

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
        if(!_attackRange.enabled)
        {
            OnStartAttack?.Invoke();
            _attackRange.enabled = true;

            _attackCooldown = StartCoroutine(AttackCooldown());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(0.5f);

        _attackRange.enabled = false;

        _attackCooldown = null;

        yield return null;
    }
}
