using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InDecreaseBuff<T> : Buff<T> where T : InDecreaseBuff<T>
{
    private List<InDecreaseInfo> _inDecreaseInfos = new List<InDecreaseInfo>();

    public InDecreaseType InDecreaseType { get; }
    public float Value { get; }
    public float RemainingType { get; }

    public InDecreaseBuff(InDecreaseType inDecreaseType, float value, float remainingTime)
    {
        InDecreaseType = inDecreaseType;
        Value = inDecreaseType == InDecreaseType.Constant ? value : 1 + 0.1f * value;
        RemainingType = remainingTime;
    }

    public override void OnAdded(BuffSystem manager)
    {
        _inDecreaseInfos.Add(new InDecreaseInfo()
        {
            InDecreaseType = InDecreaseType,
            Value = Value,
            RemainingTime = RemainingType
        });
    }

    public override void MergeBuff(T other)
    {
        _inDecreaseInfos.Add(new InDecreaseInfo()
        {
            InDecreaseType = other.InDecreaseType,
            Value = other.Value,
            RemainingTime = other.RemainingType
        });
    }

    public override void OnUpdate(BuffSystem manager)
    {
        foreach(var element in _inDecreaseInfos)
        {
            element.RemainingTime -= Time.deltaTime;
            if (element.RemainingTime <= 0) _inDecreaseInfos.Remove(element);
        }

        if (_inDecreaseInfos.Count == 0)
        {
            manager.RemoveBuff<T>();
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
