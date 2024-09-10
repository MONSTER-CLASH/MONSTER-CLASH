using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cactus Card Data", menuName = "Scriptable Object/Range/Cactus Card Data")]
public class CactusCardData : CardData
{
    [Header("Cactus Card Data")]
    public float SkillCoolTime;
    public float SkillFirstHitDamage;
    public float SkillLaterHitDamage;

    public override void UpgradeCard() { }
}
