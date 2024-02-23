using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSystem : MonoBehaviour
{
    public string Name;
    public float MaxHealth;
    public float CurrentHealth;
    public float AttackDamage;
    public float AttackSpeed;
    public float AttackRange;
    public float AttackDetectRange;
    public float MoveSpeed;

    [SerializeField] private UnitStatusData _unitStatusData;

    private void Awake()
    {
        Name = _unitStatusData.Name;
        MaxHealth = _unitStatusData.Health;
        CurrentHealth = MaxHealth;
        AttackDamage = _unitStatusData.AttackDamage;
        AttackSpeed = _unitStatusData.AttackSpeed;
        AttackRange = _unitStatusData.AttackRange;
        AttackDetectRange = _unitStatusData.AttackDetectRange;
        MoveSpeed = _unitStatusData.MoveSpeed;
    }
}
