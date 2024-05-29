using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Lightning Card Data", menuName = "Scriptable Object/Skill/Lightning Card Data")]
public class LightningCardData : CardData
{
    [Header("Lightning Card Data")]
    public float Damage;
    public float DamageUpgradeRatio;
    public float DestroyTime;

    [Header("Lightning Card Info")]
    public Sprite LightningImage;
    public string LightningName;

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
                InfoImage = LightningImage,
                InfoName = LightningName,
                InfoValue = Damage,
                NextLevelInfoValue = Damage * DamageUpgradeRatio
            }
        };
    }
}
