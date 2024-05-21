using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage Data", menuName = "Scriptable Object/Stage Data")]
public class StageData : ScriptableObject
{
    [Header("Stage Info")]
    public int StageLevel;
    public string StageName;
    public string StageDescription;

    [Header("Player Info")]
    public BaseStatusData PlayerBaseStatusData;

    [Header("Enemy Info")]
    public BaseStatusData EnemyBaseStatusData;
    public List<UnitSpawnData> LeftUnitSpawnDatas;
    public List<UnitSpawnData> RightUnitSpawnDatas;

    [Header("Stage Reward")]
    public int StageWinGold;
    public int StageDefeatGold;
    public UnitData[] RewardUnits;

    [Header("Sub Stage")]
    public bool IsSubStage;
    public int RequiredMinMainStage;
    public int RequiredMaxMainStage;
}
