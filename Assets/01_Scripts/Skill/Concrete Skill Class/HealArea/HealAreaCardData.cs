using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal Area Card Data", menuName = "Scriptable Object/Skill/Heal Area Card Data")]
public class HealAreaCardData : CardData
{
    [Header("Heal")]
    public float Heal;
    public float HealUpgradeRatio;
    public Sprite HealImage;
    public string HealName;

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
        Heal *= HealUpgradeRatio;
        TickTime *= TickTimeUpgradeRatio;
        DurationTime *= DurationTimeUpgradeRatio;
    }

    public override HaveCardInfoData[] GetCardInfoData()
    {
        return new HaveCardInfoData[]
        {
            new HaveCardInfoData
            {
                InfoImage = HealImage,
                InfoName = HealName,
                InfoValue = Heal,
                NextLevelInfoValue = Heal * HealUpgradeRatio
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
