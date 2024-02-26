using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatusSystem : StatusSystem
{
    [SerializeField] private BaseStatusData _baesStatusData;

    private void Awake()
    {
        Name = _baesStatusData.Name;
        MaxHealth = _baesStatusData.Health;
        CurrentHealth = MaxHealth;
        AttackDamage = _baesStatusData.AttackDamage;
        AttackSpeed = _baesStatusData.AttackSpeed;
        AttackRange = _baesStatusData.AttackRange;
    }
}
