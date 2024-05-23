using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data")]
public class UnitData : ScriptableObject
{
    [Space()]
    public string UnitName;
    public int UnitLevel;
    public Sprite UnitImage;
    public string UnitDescription;

    [Space()]
    public GameObject UnitModel; // 덱 오브젝트에 생성될 유닛 동상 모델 프리팹
    public GameObject UnitPrefab; // 실제 맵에 소환될 유닛 프리팹
    public int SpawnCost;
    public float SpawnCoolTime;

    [Space()]
    public int StorePrice;
    public UnitPosition UnitPosition;
    public UnitLevelData UnitLevelData;

    [Space()]
    public bool HasUnit;

    /// <summary>
    /// level 매개변수 입력 시 해당 레벨의, 미 입력 시 현재 레벨의 UnitStatusData를 반환합니다.
    /// </summary>
    public UnitStatusData GetUnitStatusData(int? level = null)
    {
        return UnitLevelData.GetLevelData(level.HasValue ? level.Value : UnitLevel);
    }

    /// <summary>
    /// level 매개변수 입력 시 해당 레벨의, 미 입력 시 현재 레벨의 UpgradeCost를 반환합니다.
    /// </summary>
    public int GetUpgradeCost(int? level = null)
    {
        return UnitLevelData.UpgradeCosts[level.HasValue ? level.Value : UnitLevel];
    }

    public bool CanUpgrade()
    {
        return UnitLevel < UnitLevelData.MaxLevel;
    }
}

public enum UnitPosition
{
    Warrior = 0,
    Wizard,
    Range,
    Tank
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
