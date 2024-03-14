using UnityEngine;

[CreateAssetMenu(fileName = "Base Status Data", menuName = "Scriptable Object/Base Status Data")]
public class BaseStatusData : ScriptableObject
{
    [Header("Base Status Data")]
    public string Name;
    public float Health;
    public float AttackDamage;
    public float AttackSpeed;
    public float AttackRange;
}
