using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Golem Card Data", menuName = "Scriptable Object/Tank/Golem Card Data")]
public class GolemCardData : CardData
{
    [Header("Golem Card Data")]
    public float SkillCoolTime;
    public float SkillStunTime;
    public GameObject SkillHitVFX;
    public GameObject SkillAttackVFX;

    public override void UpgradeCard() { }
}
