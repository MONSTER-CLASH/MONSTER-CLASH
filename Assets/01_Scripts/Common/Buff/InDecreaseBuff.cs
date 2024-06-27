using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InDecreaseBuff<T> : Buff<T> where T : InDecreaseBuff<T>
{
    private List<InDecreaseInfo> _inDecreaseInfos = new List<InDecreaseInfo>();

    public InDecreaseType InDecreaseType { get; }
    public float Value { get; }
    public float RemainingTime { get; }

    public InDecreaseBuff(InDecreaseType inDecreaseType, float value, float remainingTime)
    {
        InDecreaseType = inDecreaseType;
        Value = value;
        RemainingTime = remainingTime;
    }

    public override void OnAdded(BuffSystem manager)
    {
        _inDecreaseInfos.Add(new InDecreaseInfo()
        {
            InDecreaseType = InDecreaseType,
            Value = Value,
            RemainingTime = RemainingTime
        });
    }

    public override void MergeBuff(T other)
    {
        _inDecreaseInfos.Add(new InDecreaseInfo()
        {
            InDecreaseType = other.InDecreaseType,
            Value = other.Value,
            RemainingTime = other.RemainingTime
        });
    }

    public override void OnUpdate(BuffSystem manager)
    {
        if (_inDecreaseInfos.Count == 0)
        {
            manager.RemoveBuff<T>();
        }
        else
        {
            for (int i=0; i< _inDecreaseInfos.Count; i++)
            {
                _inDecreaseInfos[i].RemainingTime -= Time.deltaTime;
                if (_inDecreaseInfos[i].RemainingTime <= 0)
                {
                    _inDecreaseInfos.RemoveAt(i);
                    i--;
                }
            }
        }
    }

    public float GetInDecreaseBuffValue(float currentValue)
    {
        float returnValue = currentValue;

        foreach (var info in _inDecreaseInfos)
        {
            if (info.InDecreaseType == InDecreaseType.Constant)
            {
                returnValue += info.Value;
            }
            else if (info.InDecreaseType == InDecreaseType.Coefficient)
            {
                returnValue += currentValue * info.Value;
            }
        }

        return returnValue;
    }
}

public class InDecreaseInfo
{
    public InDecreaseType InDecreaseType;
    public float Value;
    public float RemainingTime;
}

public enum InDecreaseType
{
    Constant,
    Coefficient
}
