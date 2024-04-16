using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Level Data", menuName = "Scriptable Object/Unit Level Data")]
public class UnitLevelData : ScriptableObject
{
    public LevelData[] LevelDatas;

    [Serializable]
    public struct LevelData
    {
        public float Health;
        public float AttackDamage;
        public float AttackSpeed;
        public float AttackRange;
        public float AttackDetectRange;
        public float MoveSpeed;
        public int UpgradeCost;
    }

    public LevelData GetLevelData(int level)
    {
        return LevelDatas[Mathf.Min(level - 1, LevelDatas.Length - 1)];
    }
}
