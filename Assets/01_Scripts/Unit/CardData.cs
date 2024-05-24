using System;
using UnityEngine;

public abstract class CardData : ScriptableObject
{
    [Header("Card Info")]
    public string CardName;
    public Sprite CardImage;
    [TextArea] public string CardDescription;

    [Space()]
    [Header("Card Upgrade")]
    public int CardLevel;
    public int MaxCardLevel { get => UpgradeCosts.Length; }
    public int[] UpgradeCosts;

    [Space()]
    [Header("Card Spawn")]
    public GameObject CardModel; // 덱 오브젝트에 생성될 모델 프리팹
    public GameObject CardPrefab; // 실제 맵에 소환될 프리팹
    public int SpawnCost;
    public float SpawnCoolTime;

    [Space()]
    [Header("ETC")]
    public int StorePrice;
    public CardType CardType;
    public bool HaveCard;

    [Space()]
    [Header("Unit Upgrade Data")]
    public UnitUpgradeData UnitUpgradeData;

    /// <summary>
    /// level 매개변수 입력 시 해당 레벨의, 미 입력 시 현재 레벨의 UnitStatusData를 반환합니다.
    /// </summary>
    public UnitStatusData GetUnitStatusData(int? level = null)
    {
        return UnitUpgradeData.GetLevelData(level.HasValue ? level.Value : CardLevel);
    }

    /// <summary>
    /// level 매개변수 입력 시 해당 레벨의, 미 입력 시 현재 레벨의 UpgradeCost를 반환합니다.
    /// </summary>
    public int GetUpgradeCost(int? level = null)
    {
        return UpgradeCosts[level.HasValue ? level.Value : CardLevel];
    }

    public bool CanUpgrade()
    {
        return CardLevel < MaxCardLevel;
    }

    public abstract void UpgradeCard();
}

public enum CardType
{
    Warrior = 0,
    Wizard,
    Range,
    Tank,
    Skill
}

[Serializable]
public struct UnitStatusData
{
    public float Health;
    public float AttackDamage;
    public float AttackSpeed;
    public float AttackRange;
    public float AttackDetectRange;
    public float MoveSpeed;
}

[Serializable]
public struct UnitUpgradeData
{
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

        for (int i = 0; i < level - 1; i++)
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
