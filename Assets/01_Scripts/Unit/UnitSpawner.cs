using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private List<UnitSpawnData> _unitSpawnDatas;
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
    }

    private void Update()
    {
        if (!_isTeamBaseDead)
        {
            for (int i=0; i<_unitSpawnDatas.Count; i++)
            {
                if (_unitSpawnDatas[i]._isSpecialWave)
                {
                    if (_unitSpawnDatas[i]._specialWaveStartHp >= _teamBaseHealth)
                    {
                        StartCoroutine(UnitSpawnCoroutine(_unitSpawnDatas[i]));
                        _unitSpawnDatas.Remove(_unitSpawnDatas[i]);
                    }
                }
                else
                {
                    if (_unitSpawnDatas[i]._spawnTime < Time.time)
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
        for (int i=0; i<unitSpawnData._spawnCount; i++)
        {
            for (int j=0; j<unitSpawnData._spawnUnitCount; j++)
            {
                Instantiate(unitSpawnData._spawnUnit, transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(unitSpawnData._spawnDelay);
        }

        yield break;
    }
}

[Serializable]
public struct UnitSpawnData
{
    public float _spawnTime;
    public GameObject _spawnUnit;
    public int _spawnCount;
    public int _spawnUnitCount;
    public float _spawnDelay;

    public bool _isSpecialWave;
    public float _specialWaveStartHp;
}
