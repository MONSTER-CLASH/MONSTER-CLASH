using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatusSystem))]
[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(AttackSystem))]
public abstract class UnitController : MonoBehaviour
{
    private UnitStatusSystem _unitStatusSystem;
    private HealthSystem _healthSystem;
    private AttackSystem _attackSystem;

    private void Awake()
    {
        _unitStatusSystem = GetComponent<UnitStatusSystem>();
        _healthSystem = GetComponent<HealthSystem>();
        _attackSystem = GetComponent<AttackSystem>();
    }

    
}
