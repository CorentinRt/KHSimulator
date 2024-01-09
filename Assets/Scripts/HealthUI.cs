using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityHealth _playerHealth;

    int CachedMaxHealth { get; set; }


    private void Start()
    {
        _playerHealth.OnHealthUpdate += UpdateSlider;
        _playerHealth.OnMaxHealthUpdate += UpdateSlider;

        CachedMaxHealth = _playerHealth.MaxHealth;
        UpdateSlider(_playerHealth.CurrentHealth);
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealthUpdate -= UpdateSlider;
        _playerHealth.OnMaxHealthUpdate -= UpdateSlider;
    }

    void UpdateSlider(int newHealthValue)
    {
        CachedMaxHealth = _playerHealth.MaxHealth;
        _slider.maxValue = CachedMaxHealth;

        _slider.value = newHealthValue;
        _text.text = $"{newHealthValue} / {CachedMaxHealth}";
    }

}
