using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    [SerializeField] private UnitData[] _unitDatas;

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

        foreach(UnitData unitData in _unitDatas)
        {
            unitData.UnitLevel = 1;
        }
    }

    public UnitData[] GetHasUnitDatas()
    {
        List<UnitData> unitDatas = new List<UnitData>();

        for (int i=0; i<_unitDatas.Length; i++)
        {
            if (_unitDatas[i].HasUnit)
            {
                unitDatas.Add(_unitDatas[i]);
            }
        }

        return unitDatas.ToArray();
    }

    public UnitData GetUnitDataViaName(string unitName)
    {
        for (int i=0; i<_unitDatas.Length;i++)
        {
            if (_unitDatas[i].UnitName == unitName)
            {
                return _unitDatas[i];
            }
        }

        Debug.LogWarning("Not Found Unit Data Via Name");
        return null;
    }
}
