using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Level Data", menuName = "Scriptable Object/Unit Level Data")]
public class UnitLevelData : ScriptableObject
{
    public int MaxLevel { get => UpgradeCosts.Length; }
    public int[] UpgradeCosts;

    [Header("Health")]
    [SerializeField] private float _health;
    [SerializeField] private float _healthUpgradeRatio;

    [Header("Attack Damage")]
    [SerializeField] private float _attackDamage;
    [SerializeField] private float _attackDamageUpgradeRatio;

    [Header("Attack Speed")]
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackSpeedUpgradeRatio;

    [Header("Attack Range")]
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackRangeUpgradeRatio;

    [Header("Attack Detect Range")]
    [SerializeField] private float _attackDetectRange;
    [SerializeField] private float _attackDetectRangeUpgradeRatio;

    [Header("Move Speed")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveSpeedUpgradeRatio;


    public UnitStatusData GetLevelData(int level)
    {
        float health = _health;
        float attackDamage = _attackDamage;
        float attackSpeed = _attackSpeed;
        float attackRange = _attackRange;
        float attackDetectRange = _attackDetectRange;
        float moveSpeed = _moveSpeed;

        for (int i=0; i<level-1; i++)
        {
            health *= _healthUpgradeRatio;
            attackDamage *= _attackDamageUpgradeRatio;
            attackSpeed *= _attackSpeedUpgradeRatio;
            attackRange *= _attackRangeUpgradeRatio;
            attackDetectRange *= _attackDetectRangeUpgradeRatio;
            moveSpeed *= _moveSpeedUpgradeRatio;
        }

        return new UnitStatusData
        {
            Health = health,
            AttackDamage = attackDamage,
            AttackSpeed = attackSpeed,
            AttackRange = attackRange,
            AttackDetectRange = attackDetectRange,
            MoveSpeed = moveSpeed,
        };
    }
}
