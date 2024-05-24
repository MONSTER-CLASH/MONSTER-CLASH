using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mushroom Card Data", menuName = "Scriptable Object/Mushroom Card Data")]
public class MushroomCardData : CardData
{
    public override void UpgradeCard()
    {
        Debug.Log("Upgrade");
    }
}
