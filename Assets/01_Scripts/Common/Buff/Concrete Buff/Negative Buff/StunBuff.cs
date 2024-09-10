using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class StunBuff : Buff<StunBuff>
{
    protected override BuffData _buffData => BuffDataManager.Instance.StunBuffData;
    private float _remainingTime;

    public StunBuff(float stunTime)
    {
        _remainingTime = stunTime;
    }

    public override void MergeBuff(StunBuff other)
    {
        if (other._remainingTime > _remainingTime)
        {
            _remainingTime = other._remainingTime;
        }
    }

    public override void OnAdded(BuffSystem manager)
    {
    }

    public override void OnUpdate(BuffSystem manager)
    {
        _remainingTime -= Time.deltaTime;
        if (_remainingTime <= 0)
        {
            manager.RemoveBuff<StunBuff>();
        }
    }

    public override void OnDeleted(BuffSystem manager)
    {
    }
}
