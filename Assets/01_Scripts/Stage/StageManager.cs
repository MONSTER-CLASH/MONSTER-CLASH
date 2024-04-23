using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static int LastClearStageLevel = 0;

    [SerializeField] private StageData _stageData;
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
        Instantiate(_stageResultUIPrefab, _stageResultUIParent).GetComponent<StageResultUIController>().SetStageResultUI(_stageData.StageLevel, _stageTime, _stageData.StageWinGold, true);
        DeckManager.Gold += _stageData.StageWinGold;
        if (!_stageData.IsSubStage) LastClearStageLevel = _stageData.StageLevel;

        for (int i=0; i<_stageData.RewardUnits.Length; i++)
        {
            for (int j=0; j<UnitManager.Instance.UnitDatas.Length; j++)
            {
                if (_stageData.RewardUnits[i] == UnitManager.Instance.UnitDatas[j])
                {
                    UnitManager.Instance.UnitDatas[j].HasUnit = true;
                }
            }
        }
    }

    private void PlayerDefeat(GameObject killer)
    {
        Instantiate(_stageResultUIPrefab, _stageResultUIParent).GetComponent<StageResultUIController>().SetStageResultUI(_stageData.StageLevel, _stageTime, _stageData.StageDefeatGold, false);
        DeckManager.Gold += _stageData.StageDefeatGold;
    }
}
