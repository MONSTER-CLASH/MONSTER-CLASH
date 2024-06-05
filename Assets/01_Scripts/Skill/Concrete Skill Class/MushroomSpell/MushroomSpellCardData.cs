using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mushroom Spell Card Data", menuName = "Scriptable Object/Skill/Mushroom Spell Card Data")]
public class MushroomSpellCardData : CardData
{
    [Header("Mushroom")]
    public GameObject MushroomPrefab;

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
        TickTime *= TickTimeUpgradeRatio;
        DurationTime *= DurationTimeUpgradeRatio;
    }

    public override HaveCardInfoData[] GetCardInfoData()
    {
        return new HaveCardInfoData[]
        {
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
