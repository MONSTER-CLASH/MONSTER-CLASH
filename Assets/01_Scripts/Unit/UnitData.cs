using System.Collections;
using System.Collections.Generic;
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
}

public enum UnitPosition
{
    Warrior = 0,
    Wizard,
    Range,
    Tank
}
