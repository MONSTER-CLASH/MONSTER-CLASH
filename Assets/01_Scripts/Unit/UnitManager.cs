using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    public UnitData[] UnitDatas;

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

        foreach(UnitData unitData in UnitDatas)
        {
            unitData.UnitLevel = 1;
        }
    }

    public UnitData[] GetHasUnitDatas()
    {
        List<UnitData> unitDatas = new List<UnitData>();

        for (int i=0; i<UnitDatas.Length; i++)
        {
            if (UnitDatas[i].HasUnit)
            {
                unitDatas.Add(UnitDatas[i]);
            }
        }

        return unitDatas.ToArray();
    }

    public UnitData GetUnitDataViaName(string unitName)
    {
        for (int i=0; i<UnitDatas.Length;i++)
        {
            if (UnitDatas[i].UnitName == unitName)
            {
                return UnitDatas[i];
            }
        }

        Debug.LogWarning("Not Found Unit Data Via Name");
        return null;
    }
}
