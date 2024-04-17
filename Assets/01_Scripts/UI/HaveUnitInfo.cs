using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveUnitInfo : MonoBehaviour
{
    [Header("Upper UI Elements")]
    [SerializeField] private Image _unitImage;
    [SerializeField] private TextMeshProUGUI _unitNameText;
    [SerializeField] private TextMeshProUGUI _unitLevelText;
    [SerializeField] private TextMeshProUGUI _unitPositionText;

    [Header("Lower UI Elements")]
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _attackDamageText;
    [SerializeField] private TextMeshProUGUI _attackSpeedText;
    [SerializeField] private TextMeshProUGUI _attackRangeText;
    [SerializeField] private TextMeshProUGUI _attackDetectRangeText;
    [SerializeField] private TextMeshProUGUI _moveSpeedText;

    [Space()]
    [SerializeField] private TextMeshProUGUI _upgradeCostText;

    private UnitData _unitData;
    private HaveUnitItem _parentUnitItem;

    private void Awake()
    {
        transform.position = transform.parent.parent.parent.parent.position;
        _upgradeCostText.transform.parent.GetComponent<Button>().onClick.AddListener(UpgradeUnit);
    }

    public void ShowHaveUnitInfo(UnitData unitData, HaveUnitItem parentUnitItem = null)
    {
        if (_unitData == null) _unitData = unitData;
        if (_parentUnitItem == null) _parentUnitItem = parentUnitItem;

        //_unitImage.sprite = unitData.UnitImage;
        _unitNameText.text = _unitData.UnitName;
        _unitLevelText.text = "레벨 " + _unitData.UnitLevel + " +1";
        switch (_unitData.UnitPosition)
        {
            case UnitPosition.Warrior:
                _unitPositionText.text = "전사";
                break;
            case UnitPosition.Wizard:
                _unitPositionText.text = "마법사";
                break;
            case UnitPosition.Range:
                _unitPositionText.text = "원거리 딜러";
                break;
            case UnitPosition.Tank:
                _unitPositionText.text = "탱커";
                break;
        }

        float health = _unitData.GetUnitStatusData().Health;
        float nextLevelHealth = _unitData.CanUpgrade() ? _unitData.GetUnitStatusData(_unitData.UnitLevel + 1).Health : 0;
        _healthText.text = health + (_unitData.CanUpgrade() ? $" +{ nextLevelHealth - health }" : "");

        float attackDamage = _unitData.GetUnitStatusData().AttackDamage;
        float nextLevelAttackDamage = _unitData.CanUpgrade() ? _unitData.GetUnitStatusData(_unitData.UnitLevel + 1).AttackDamage : 0;
        _attackDamageText.text = attackDamage + (_unitData.CanUpgrade() ? $" +{ nextLevelAttackDamage - attackDamage }" : "");

        float attackSpeed = _unitData.GetUnitStatusData().AttackSpeed;
        float nextLevelAttackSpeed = _unitData.CanUpgrade() ? _unitData.GetUnitStatusData(_unitData.UnitLevel + 1).AttackSpeed : 0;
        _attackSpeedText.text = attackSpeed + (_unitData.CanUpgrade() ? $" +{ nextLevelAttackSpeed - attackSpeed }" : "");

        float attackRange = _unitData.GetUnitStatusData().AttackRange;
        float nextLevelAttackRange = _unitData.CanUpgrade() ? _unitData.GetUnitStatusData(_unitData.UnitLevel + 1).AttackRange : 0;
        _attackRangeText.text = attackRange + (_unitData.CanUpgrade() ? $" +{ nextLevelAttackRange - attackRange }" : "");

        float attackDetectRange = _unitData.GetUnitStatusData().AttackDetectRange;
        float nextLevelAttackDetectRange = _unitData.CanUpgrade() ? _unitData.GetUnitStatusData(_unitData.UnitLevel + 1).AttackDetectRange : 0;
        _attackDetectRangeText.text = attackDetectRange + (_unitData.CanUpgrade() ? $" +{ nextLevelAttackDetectRange - attackDetectRange }" : "");

        float moveSpeed = _unitData.GetUnitStatusData().MoveSpeed;
        float nextLevelMoveSpeed = _unitData.CanUpgrade() ? _unitData.GetUnitStatusData(_unitData.UnitLevel + 1).MoveSpeed : 0;
        _moveSpeedText.text = moveSpeed + (_unitData.CanUpgrade() ? $" +{ nextLevelMoveSpeed - moveSpeed }" : "");

        _upgradeCostText.text = _unitData.UnitLevel < _unitData.UnitLevelData.MaxLevel ? _unitData.GetUpgradeCost().ToString() : "최대 레벨";
    }

    public void UpgradeUnit()
    {
        if (_unitData.UnitLevel < _unitData.UnitLevelData.MaxLevel && DeckManager.Gold >= _unitData.GetUpgradeCost())
        {
            DeckManager.Gold -= _unitData.GetUpgradeCost();
            _unitData.UnitLevel++;
            ShowHaveUnitInfo(_unitData);
            _parentUnitItem.UpdateUnitItem();
        }
    }
}
