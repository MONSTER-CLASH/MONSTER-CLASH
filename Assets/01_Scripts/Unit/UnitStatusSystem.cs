using UnityEngine;

public class UnitStatusSystem : StatusSystem
{
    public float AttackDetectRange;
    public float MoveSpeed;
    public int UnitLevel;

    private void Awake()
    {
        CardData unitData = CardManager.Instance.GetCardDataViaName(Name);

        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Name = unitData.CardName;
            MaxHealth = unitData.GetUnitStatusData().Health;
            CurrentHealth = MaxHealth;
            AttackDamage = unitData.GetUnitStatusData().AttackDamage;
            AttackSpeed = unitData.GetUnitStatusData().AttackSpeed;
            AttackRange = unitData.GetUnitStatusData().AttackRange;
            AttackDetectRange = unitData.GetUnitStatusData().AttackDetectRange;
            MoveSpeed = unitData.GetUnitStatusData().MoveSpeed;

            UnitLevel = unitData.CardLevel;
        }
    }

    public void SetUnitStatusForEnemyUnit(int unitLevel)
    {
        CardData unitData = CardManager.Instance.GetCardDataViaName(Name);

        Name = unitData.CardName;
        MaxHealth = unitData.GetUnitStatusData(unitLevel).Health;
        CurrentHealth = MaxHealth;
        AttackDamage = unitData.GetUnitStatusData(unitLevel).AttackDamage;
        AttackSpeed = unitData.GetUnitStatusData(unitLevel).AttackSpeed;
        AttackRange = unitData.GetUnitStatusData(unitLevel).AttackRange;
        AttackDetectRange = unitData.GetUnitStatusData(unitLevel).AttackDetectRange;
        MoveSpeed = unitData.GetUnitStatusData(unitLevel).MoveSpeed;

        UnitLevel = unitLevel;
    }
}
