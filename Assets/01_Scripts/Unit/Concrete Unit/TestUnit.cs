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
}
