using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    public CardData[] UnitDatas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        foreach(CardData unitData in UnitDatas)
        {
            unitData.CardLevel = 1;
        }
    }

    public CardData[] GetHasUnitDatas()
    {
        List<CardData> unitDatas = new List<CardData>();

        for (int i=0; i<UnitDatas.Length; i++)
        {
            if (UnitDatas[i].HaveCard)
            {
                unitDatas.Add(UnitDatas[i]);
            }
        }

        return unitDatas.ToArray();
    }

    public CardData GetUnitDataViaName(string unitName)
    {
        for (int i=0; i<UnitDatas.Length;i++)
        {
            if (UnitDatas[i].CardName == unitName)
            {
                return UnitDatas[i];
            }
        }

        Debug.LogWarning("Not Found Unit Data Via Name");
        return null;
    }
}
