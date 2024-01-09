using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityGold _playerGold;

    // Start is called before the first frame update
    void Start()
    {
        _playerGold.OnGoldUpdate += UpdateGoldText;
        UpdateGoldText(_playerGold.CurrentGold);
    }
    private void OnDestroy()
    {
        _playerGold.OnGoldUpdate -= UpdateGoldText;
    }

    void UpdateGoldText(int newGoldValue)
    {
        _text.text = $"Gold : {newGoldValue}";
    }
}
