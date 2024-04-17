using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data")]
public class UnitData : ScriptableObject
{
    [Space()]
    public string UnitName;
    public int UnitLevel;
    public Sprite UnitImage;

    [Space()]
    public UnitPosition UnitPosition;
    public UnitLevelData UnitLevelData;

    [Space()]
    public bool HasUnit;

    /// <summary>
    /// level �Ű����� �Է� �� �ش� ������, �� �Է� �� ���� ������ UnitStatusData�� ��ȯ�մϴ�.
    /// </summary>
    public UnitStatusData GetUnitStatusData(int? level = null)
    {
        return UnitLevelData.GetLevelData(level.HasValue ? level.Value : UnitLevel).UnitStatusData;
    }


    public int GetUpgradeCost(int? level = null)
    {
        return UnitLevelData.GetLevelData(level.HasValue ? level.Value : UnitLevel).UpgradeCost;
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
