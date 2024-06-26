using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skeleton Card Data", menuName = "Scriptable Object/Warrior/Skeleton Card Data")]
public class SkeletonCardData : CardData
{
    [Header("Skeleton Card Data")]
    public GameObject SkillVFX;
    public float SkillCoolTime;
    public float SkillIncreaseCoefficient;
    public float SkillDurationTime;

    public override void UpgradeCard() { }
}
