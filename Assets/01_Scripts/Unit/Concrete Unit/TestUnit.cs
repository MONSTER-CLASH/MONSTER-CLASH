using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnit : UnitController
{
    private void Update()
    {
        Move();
        DetectAttackTarget();
        Attack();
    }

    protected override void HandleAttack()
    {
        _attackSystem.SendDamage(_attackTarget, _unitStatusSystem.AttackDamage, gameObject);
        Debug.Log("Attacked");
    }
}
