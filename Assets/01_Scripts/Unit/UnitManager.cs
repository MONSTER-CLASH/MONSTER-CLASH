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
            Debug.LogError("UnitManager Instance Error\nGameObject : " + gameObject);
        }
        DontDestroyOnLoad(gameObject);
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
}
