using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimerBuff<T> : Buff<T> where T : TimerBuff<T>
{
    private float _remainingTime;

    public TimerBuff(float remainingTime)
    {
        _remainingTime = remainingTime;
    }

    public override void OnUpdate(BuffSystem manager)
    {
        _remainingTime -= Time.deltaTime;
        if (_remainingTime <= 0)
        {
            manager.RemoveBuff<T>();
        }
    }
}
