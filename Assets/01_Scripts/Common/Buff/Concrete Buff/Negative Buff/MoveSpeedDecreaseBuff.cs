using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedDecreaseBuff : TimerBuff<MoveSpeedDecreaseBuff>
{
    protected override BuffData _buffData => BuffDataManager.Instance.MoveSpeedDecreaseBuffData;

    public MoveSpeedDecreaseBuff(float remainingTime) : base(remainingTime)
    {
        
    }

    public override void MergeBuff(MoveSpeedDecreaseBuff other)
    {
    }

    public override void OnAdded(BuffSystem manager)
    {
    }

    public override void OnDeleted(BuffSystem manager)
    {
    }
}
