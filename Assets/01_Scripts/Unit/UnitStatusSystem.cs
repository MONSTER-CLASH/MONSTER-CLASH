using UnityEngine;

public class UnitStatusSystem : StatusSystem
{
    public float AttackDetectRange;
    public float MoveSpeed;
    [SerializeField] private int _unitLevel;

    private void Awake()
    {
        UnitData unitData = UnitManager.Instance.GetUnitDataViaName(Name);

        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Name = unitData.UnitName;
            MaxHealth = unitData.UnitLevelData.GetLevelData(unitData.UnitLevel).Health;
            CurrentHealth = MaxHealth;
            AttackDamage = unitData.UnitLevelData.GetLevelData(unitData.UnitLevel).AttackDamage;
            AttackSpeed = unitData.UnitLevelData.GetLevelData(unitData.UnitLevel).AttackSpeed;
            AttackRange = unitData.UnitLevelData.GetLevelData(unitData.UnitLevel).AttackRange;
            AttackDetectRange = unitData.UnitLevelData.GetLevelData(unitData.UnitLevel).AttackDetectRange;
            MoveSpeed = unitData.UnitLevelData.GetLevelData(unitData.UnitLevel).MoveSpeed;
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Name = unitData.UnitName;
            MaxHealth = unitData.UnitLevelData.GetLevelData(_unitLevel).Health;
            CurrentHealth = MaxHealth;
            AttackDamage = unitData.UnitLevelData.GetLevelData(_unitLevel).AttackDamage;
            AttackSpeed = unitData.UnitLevelData.GetLevelData(_unitLevel).AttackSpeed;
            AttackRange = unitData.UnitLevelData.GetLevelData(_unitLevel).AttackRange;
            AttackDetectRange = unitData.UnitLevelData.GetLevelData(_unitLevel).AttackDetectRange;
            MoveSpeed = unitData.UnitLevelData.GetLevelData(_unitLevel).MoveSpeed;
        }
    }
}
