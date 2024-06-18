using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff Data", menuName = "Scriptable Object/Buff Data")]
public class BuffData : ScriptableObject
{
    public string BuffName;
    public string BuffDescription;
    public Sprite BuffImage;
    public BuffType BuffType;
}

public enum BuffType
{
    PositiveBuff,
    NegativeBuff
}