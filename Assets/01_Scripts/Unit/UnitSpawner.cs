using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{

}

[Serializable]
public struct UnitSpawnData
{
    public float _spawnTime;
    public GameObject _spawnUnit;
    public int _spawnUnitCount;
    public int _spawnCount;
    public float _spawnDelay;

    public bool _isSpecialWave;
    public float _specialWaveStartHp;
}
