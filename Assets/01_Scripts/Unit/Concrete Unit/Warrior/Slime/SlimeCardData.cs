using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slime Card Data", menuName = "Scriptable Object/Warrior/Slime Card Data")]
public class SlimeCardData : CardData
{
    [Header("Slime Card Data")]
    public GameObject SkillVFX;
    public float SkillCoolTime;
    public float SkillRange;

    public override void UpgradeCard() { }
}
