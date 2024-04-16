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
            MaxHealth = unitData.GetUnitStatusData().Health;
            CurrentHealth = MaxHealth;
            AttackDamage = unitData.GetUnitStatusData().AttackDamage;
            AttackSpeed = unitData.GetUnitStatusData().AttackSpeed;
            AttackRange = unitData.GetUnitStatusData().AttackRange;
            AttackDetectRange = unitData.GetUnitStatusData().AttackDetectRange;
            MoveSpeed = unitData.GetUnitStatusData().MoveSpeed;
        }
    }

    public void SetUnitStatusForEnemyUnit(int unitLevel)
    {
        UnitData unitData = UnitManager.Instance.GetUnitDataViaName(Name);

        Name = unitData.UnitName;
        MaxHealth = unitData.GetUnitStatusData(unitLevel).Health;
        CurrentHealth = MaxHealth;
        AttackDamage = unitData.GetUnitStatusData(unitLevel).AttackDamage;
        AttackSpeed = unitData.GetUnitStatusData(unitLevel).AttackSpeed;
        AttackRange = unitData.GetUnitStatusData(unitLevel).AttackRange;
        AttackDetectRange = unitData.GetUnitStatusData(unitLevel).AttackDetectRange;
        MoveSpeed = unitData.GetUnitStatusData(unitLevel).MoveSpeed;
    }
}
