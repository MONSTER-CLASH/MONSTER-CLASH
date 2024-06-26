using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamageIncreaseBuff : InDecreaseBuff<AttackDamageIncreaseBuff>
{
    public AttackDamageIncreaseBuff(InDecreaseType inDecreaseType, float value, float remainingTime) : 
        base(inDecreaseType, value, remainingTime) { }

    protected override BuffData _buffData => BuffDataManager.Instance.AttackDamageIncreaseBuffData;

    public override void OnDeleted(BuffSystem manager) { }
}
