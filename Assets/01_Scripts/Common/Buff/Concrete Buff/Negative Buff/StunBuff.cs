using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class StunBuff : TimerBuff<StunBuff>
{
    protected override BuffData _buffData => BuffDataManager.Instance.StunBuffData;

    public StunBuff(float stunTime) : base(stunTime)
    {

    }

    public override void MergeBuff(StunBuff other)
    {
    }

    public override void OnAdded(BuffSystem manager)
    {
    }

    public override void OnDeleted(BuffSystem manager)
    {
    }
}
