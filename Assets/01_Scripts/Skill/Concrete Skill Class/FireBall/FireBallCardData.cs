using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fire Ball Card Data", menuName = "Scriptable Object/Skill/Fire Ball Card Data")]
public class FireBallCardData : CardData
{
    [Header("Fire Ball Card Data")]
    public float Damage;
    public float DamageUpgradeRatio;
    public float DestroyTime;

    [Header("Fire Ball Card Info")]
    public Sprite FireBallImage;
    public string FireBallName;

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
                InfoImage = FireBallImage,
                InfoName = FireBallName,
                InfoValue = Damage,
                NextLevelInfoValue = Damage * DamageUpgradeRatio
            }
        };
    }
}
