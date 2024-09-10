using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Demon King Card Data", menuName = "Scriptable Object/Demon King Card Data")]
public class DemonKingCardData : CardData
{
    [Header("DemonKing Card Data")]
    public float SkillCoolTime;
    public float SkillDamage;

    public override void UpgradeCard() { }
}
