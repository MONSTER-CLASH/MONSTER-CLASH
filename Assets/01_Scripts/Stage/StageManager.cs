using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private int _stageLevel;
    [SerializeField] private int _stageRewardGold;
    [SerializeField] private GameObject _stageResultUIPrefab;
    [SerializeField] private Transform _stageResultUIParent;

    private float _stageTime;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<HealthSystem>().OnDead += PlayerDefeat;
        GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<HealthSystem>().OnDead += PlayerWin;
    }

    private void Update()
    {
        _stageTime += Time.deltaTime;
    }

    private void PlayerWin(GameObject killer)
    {
        Instantiate(_stageResultUIPrefab, _stageResultUIParent).GetComponent<StageResultUIController>().SetStageResultUI(_stageLevel, _stageTime, _stageRewardGold, true);
        DeckManager.Gold += _stageRewardGold;
    }

    private void PlayerDefeat(GameObject killer)
    {
        Instantiate(_stageResultUIPrefab, _stageResultUIParent).GetComponent<StageResultUIController>().SetStageResultUI(_stageLevel, _stageTime, _stageRewardGold, false);
    }
}
