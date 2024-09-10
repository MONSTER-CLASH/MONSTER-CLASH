using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dragon Card Data", menuName = "Scriptable Object/Range/Dragon Card Data")]
public class DragonCardData : CardData
{
    [Header("Dragon Card Data")]
    public GameObject SkillVFX;
    public float SkillCoolTime;
    public float SkillTickDamage;

    public override void UpgradeCard() { }
}
