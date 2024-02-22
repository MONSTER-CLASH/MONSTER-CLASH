using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusSystem : MonoBehaviour
{
    public string Name;
    public float MaxHealth;
    public float CurrentHealth;
    public float Attack;
    public float AttackSpeed;
    public float MoveSpeed;

    [SerializeField] private UnitStatusData _unitStatusData;

    private void Awake()
    {
        Name = _unitStatusData.Name;
        MaxHealth = _unitStatusData.Health;
        CurrentHealth = MaxHealth;
        Attack = _unitStatusData.Attack;
        AttackSpeed = _unitStatusData.AttackSpeed;
        MoveSpeed = _unitStatusData.MoveSpeed;
    }
}
