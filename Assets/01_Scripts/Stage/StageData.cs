using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage Data", menuName = "Scriptable Object/Stage Data")]
public class StageData : ScriptableObject
{
    [Space()]
    public int StageLevel;
    public string StageName;
    public string StageDescription;

    [Space()]
    public int StageWinGold;
    public int StageDefeatGold;
    public bool IsSubStage;
    public UnitData[] RewardUnits;
}
