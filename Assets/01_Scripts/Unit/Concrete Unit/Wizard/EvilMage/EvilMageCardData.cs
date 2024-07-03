using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Evil Mage Card Data", menuName = "Scriptable Object/Wizard/Evil Mage Card Data")]
public class EvilMageCardData : CardData
{
    [Header("Evil Mage Card Data")]
    public float SkillCoolTime;
    public float SkillHitDamage;
    public float SkillSplashDamage;
    public float SkillStunTime;

    public override void UpgradeCard() { }
}
