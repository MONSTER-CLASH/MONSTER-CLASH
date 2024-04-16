using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data")]
public class UnitData : ScriptableObject
{
    public Sprite UnitImage;
    public int UnitLevel;
    public UnitPosition UnitPosition;
    public UnitLevelData UnitLevelData;
    public UnitStatusData UnitStatusData;
}

public enum UnitPosition
{
    Warrior = 0,
    Wizard,
    Range,
    Tank
}
