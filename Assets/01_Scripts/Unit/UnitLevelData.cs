using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Level Data", menuName = "Scriptable Object/Unit Level Data")]
public class UnitLevelData : ScriptableObject
{
    public int MaxLevel { get => _levelDatas.Length; }
    [SerializeField] private LevelData[] _levelDatas;

    [Serializable]
    public struct LevelData
    {
        public UnitStatusData UnitStatusData;
        public int UpgradeCost;  // 현재 레벨에서 다음 레벨로 업그레이드 하기 위해 필요한 골드량
    }

    public LevelData GetLevelData(int level)
    {
        return _levelDatas[Mathf.Min(level - 1, _levelDatas.Length - 1)];
    }
}
