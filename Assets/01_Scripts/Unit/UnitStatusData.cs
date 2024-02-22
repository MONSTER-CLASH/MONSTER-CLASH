using UnityEngine;

[CreateAssetMenu(fileName = "Unit Status Data", menuName = "Scriptable Object/Unit Status Data")]
public class UnitStatusData : ScriptableObject
{
    [Header("Unit Status Data")]
    public string Name;
    public float Health;
    public float Attack;
    public float AttackSpeed;
    public float MoveSpeed;
}
