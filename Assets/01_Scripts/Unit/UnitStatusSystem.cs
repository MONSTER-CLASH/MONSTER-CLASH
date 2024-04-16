using UnityEngine;

public class UnitStatusSystem : StatusSystem
{
    public float AttackDetectRange;
    public float MoveSpeed;
    [SerializeField] private int unitLevel;

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
    }

    public void SetUnitStatusForEnemyUnit(int unitLevel)
    {
        UnitData unitData = UnitManager.Instance.GetUnitDataViaName(Name);

        Name = unitData.UnitName;
        MaxHealth = unitData.UnitLevelData.GetLevelData(unitLevel).Health;
        CurrentHealth = MaxHealth;
        AttackDamage = unitData.UnitLevelData.GetLevelData(unitLevel).AttackDamage;
        AttackSpeed = unitData.UnitLevelData.GetLevelData(unitLevel).AttackSpeed;
        AttackRange = unitData.UnitLevelData.GetLevelData(unitLevel).AttackRange;
        AttackDetectRange = unitData.UnitLevelData.GetLevelData(unitLevel).AttackDetectRange;
        MoveSpeed = unitData.UnitLevelData.GetLevelData(unitLevel).MoveSpeed;
    }
}
