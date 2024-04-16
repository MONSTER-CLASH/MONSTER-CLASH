using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Level Data", menuName = "Scriptable Object/Unit Level Data")]
public class UnitLevelData : ScriptableObject
{
    [SerializeField] private LevelData[] _levelDatas;

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
        return _levelDatas[Mathf.Min(level - 1, _levelDatas.Length - 1)];
    }
}
