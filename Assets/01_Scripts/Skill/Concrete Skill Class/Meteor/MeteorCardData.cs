using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Meteor Card Data", menuName = "Scriptable Object/Skill/Meteor Card Data")]
public class MeteorCardData : CardData
{
    [Header("Meteor Card Data")]
    public float Damage;
    public float DamageUpgradeRatio;
    public float DestroyTime;

    [Header("Meteor Card Info")]
    public Sprite MeteorImage;
    public string MeteorName;

    public override void UpgradeCard()
    {
        Damage *= DamageUpgradeRatio;
    }

    public override HaveCardInfoData[] GetCardInfoData()
    {
        return new HaveCardInfoData[]
        {
            new HaveCardInfoData
            {
                InfoImage = MeteorImage,
                InfoName = MeteorName,
                InfoValue = Damage,
                NextLevelInfoValue = Damage * DamageUpgradeRatio
            }
        };
    }
}
