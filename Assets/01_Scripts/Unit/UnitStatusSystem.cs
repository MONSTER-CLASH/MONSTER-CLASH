using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatusSystem : StatusSystem
{
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
