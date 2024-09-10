using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fire Area Card Data", menuName = "Scriptable Object/Skill/Fire Area Card Data")]
public class FireAreaCardData : CardData
{
    [Header("Damage")]
    public float Damage;
    public float DamageUpgradeRatio;
    public Sprite DamageImage;
    public string DamageName;

    [Header("Tick Time")]
    public float TickTime;
    public float TickTimeUpgradeRatio;
    public Sprite TickTimeImage;
    public string TickTimeName;

    [Header("Duration Time")]
    public float DurationTime;
    public float DurationTimeUpgradeRatio;
    public Sprite DurationTimeImage;
    public string DurationTimeName;

    public override void UpgradeCard()
    {
        Damage *= DamageUpgradeRatio;
        TickTime *= TickTimeUpgradeRatio;
        DurationTime *= DurationTimeUpgradeRatio;
    }

    public override HaveCardInfoData[] GetCardInfoData()
    {
        return new HaveCardInfoData[]
        {
            new HaveCardInfoData
            {
                InfoImage = DamageImage,
                InfoName = DamageName,
                InfoValue = Damage,
                NextLevelInfoValue = Damage * DamageUpgradeRatio
            },
            new HaveCardInfoData
            {
                InfoImage = TickTimeImage,
                InfoName = TickTimeName,
                InfoValue = TickTime,
                NextLevelInfoValue = TickTime * TickTimeUpgradeRatio
            },
            new HaveCardInfoData
            {
                InfoImage = DurationTimeImage,
                InfoName = DurationTimeName,
                InfoValue = DurationTime,
                NextLevelInfoValue = DurationTime * DurationTimeUpgradeRatio
            }
        };
    }
}
