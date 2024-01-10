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
    public event Action OnHealthDecrease;
    public event Action OnHealthIncrease;

    public event Action<int> OnMaxHealthUpdate;
    public event Action OnMaxHealthIncrease;

    [SerializeField] float _deathCooldown;
    public event Action OnDie;

    [SerializeField] float _invincibilityCooldown;
    private Coroutine _invincibilityCoroutine;
    private bool _isInvincible;

    [SerializeField] private UnityEvent _onHealEffects;
    [SerializeField] private UnityEvent _onLevelUpEffects;

    public bool IsDead { get; private set; }
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }



    public void DecreaseHealth(int value)
    {
        if (!_isInvincible)
        {
            CurrentHealth -= value;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, _maxHealth);
            OnHealthUpdate?.Invoke(CurrentHealth);
            if(CurrentHealth <= 0)
            {
                Die();
            }
            else
            {
                GetInvincibility();
                OnHealthDecrease?.Invoke();
            }
        }
    }
    public void IncreaseHealth(int value)
    {
        _onHealEffects?.Invoke();
        CurrentHealth += value;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, _maxHealth);
        OnHealthUpdate?.Invoke(CurrentHealth);

        OnHealthIncrease?.Invoke();
    }
    public void IncreaseMaxHealth(int value)
    {
        _onLevelUpEffects?.Invoke();
        _maxHealth += value;
        CurrentHealth += value;
        OnMaxHealthUpdate?.Invoke(CurrentHealth);
        OnMaxHealthIncrease?.Invoke();
    }
    private void GetInvincibility()
    {
        _isInvincible = true;
        _invincibilityCoroutine = StartCoroutine(InvincibilityCooldown());
    }
    private void Die()
    {
        IsDead = true;
        StartCoroutine(DeathCooldown());
        OnDie?.Invoke();

    }
    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }
    private void Start()
    {

    }

    IEnumerator DeathCooldown()
    {
        yield return new WaitForSeconds(_deathCooldown);

        Destroy(gameObject);

        yield return null;
    }
    IEnumerator InvincibilityCooldown()
    {
        yield return new WaitForSeconds(_invincibilityCooldown);

        _isInvincible = false;
        _invincibilityCoroutine = null;

        yield return null;
    }
}
