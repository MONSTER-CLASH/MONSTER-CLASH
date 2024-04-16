using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveUnitInfo : MonoBehaviour
{
    [Header("Upper UI Elements")]
    [SerializeField] private Image _unitImage;
    [SerializeField] private TextMeshProUGUI _unitName;
    [SerializeField] private TextMeshProUGUI _unitLevel;
    [SerializeField] private TextMeshProUGUI _unitPosition;

    [Header("Lower UI Elements")]
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _attackDamageText;
    [SerializeField] private TextMeshProUGUI _attackSpeedText;
    [SerializeField] private TextMeshProUGUI _attackRangeText;
    [SerializeField] private TextMeshProUGUI _attackDetectRangeText;
    [SerializeField] private TextMeshProUGUI _moveSpeedText;

    [Space()]
    [SerializeField] private TextMeshProUGUI _upgradeCostText;

    public void ShowHaveUnitInfo(UnitData unitData)
    {
        _unitImage.sprite = unitData.UnitImage;
        _unitName.text = unitData.UnitName;
        _unitLevel.text = "레벨 " + unitData.UnitLevel + " +1";
        switch (unitData.UnitPosition)
        {
            case UnitPosition.Warrior:
                _unitPosition.text = "전사";
                break;
            case UnitPosition.Wizard:
                _unitPosition.text = "마법사";
                break;
            case UnitPosition.Range:
                _unitPosition.text = "원거리 딜러";
                break;
            case UnitPosition.Tank:
                _unitPosition.text = "탱커";
                break;
        }

        float health = unitData.UnitLevelData.GetLevelData(unitData.UnitLevel).Health;
        float upgradeHealthValue = unitData.UnitLevelData.GetLevelData(unitData.UnitLevel + 1).Health - health;

        //_healthText.text = unitData.UnitLevelData.GetLevelData(unitData.UnitLevel).Health + 
        //    unitData.UnitLevel < unitData.UnitLevelData.MaxLevel ? " +" + (unitData.UnitLevelData.GetLevelData(unitData.UnitLevel + 1).Health - );
    }
}
