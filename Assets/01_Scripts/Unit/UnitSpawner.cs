using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private bool _isLeft;
    private List<UnitSpawnData> _unitSpawnDatas;
    private HealthSystem _teamBaseHealthSystem;
    private BaseStatusSystem _teamBaseStatusSystem;
    private bool _isTeamBaseDead => _teamBaseHealthSystem ? _teamBaseHealthSystem.IsDead : false;
    private float _teamBaseHealth => _teamBaseStatusSystem ? _teamBaseStatusSystem.CurrentHealth : 0;

    private void Awake()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _teamBaseStatusSystem = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<BaseStatusSystem>();
            _teamBaseHealthSystem = GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<HealthSystem>();
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            _teamBaseStatusSystem = GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<BaseStatusSystem>();
            _teamBaseHealthSystem = GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<HealthSystem>();
        }

        if (_isLeft)
        {
            _unitSpawnDatas = new List<UnitSpawnData>(StageManager.StageData.LeftUnitSpawnDatas);
        }
        else
        {
            _unitSpawnDatas = new List<UnitSpawnData>(StageManager.StageData.RightUnitSpawnDatas);
        }
    }

    private void Update()
    {
        if (!_isTeamBaseDead)
        {
            for (int i=0; i<_unitSpawnDatas.Count; i++)
            {
                if (_unitSpawnDatas[i].IsSpecialWave)
                {
                    if (_unitSpawnDatas[i].SpecialWaveStartHp >= _teamBaseHealth)
                    {
                        StartCoroutine(UnitSpawnCoroutine(_unitSpawnDatas[i]));
                        SpecialWaveWarningShower.Instance.ShowWarning();
                        _unitSpawnDatas.Remove(_unitSpawnDatas[i]);
                    }
                }
                else
                {
                    if (_unitSpawnDatas[i].SpawnTime < Time.time)
                    {
                        StartCoroutine(UnitSpawnCoroutine(_unitSpawnDatas[i]));
                        _unitSpawnDatas.Remove(_unitSpawnDatas[i]);
                    }
                }
            }
        }
    }

    private IEnumerator UnitSpawnCoroutine(UnitSpawnData unitSpawnData)
    {
        for (int i=0; i<unitSpawnData.SpawnCount; i++)
        {
            for (int j=0; j<unitSpawnData.SpawnUnitCount; j++)
            {
                Instantiate(unitSpawnData.SpawnUnit, transform.position, Quaternion.identity).GetComponent<UnitStatusSystem>().SetUnitStatusForEnemyUnit(unitSpawnData.UnitLevel);
            }

            yield return new WaitForSeconds(unitSpawnData.SpawnDelay);
        }

        yield break;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}

[Serializable]
public struct UnitSpawnData
{
    public float SpawnTime;
    public GameObject SpawnUnit;
    public int UnitLevel;
    public int SpawnCount;
    public int SpawnUnitCount;
    public float SpawnDelay;

    public bool IsSpecialWave;
    public float SpecialWaveStartHp;
}
