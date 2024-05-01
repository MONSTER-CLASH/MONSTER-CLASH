using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public int MercenaryCoin;

    [SerializeField] private StageData _stageData;
    [SerializeField] private GameObject _stageResultUIPrefab;
    [SerializeField] private Transform _stageResultUIParent;
    [SerializeField] private int _getMercenaryCoinValuePerSecond;

    private float _stageTime;
    private bool _isStageEnd;

    private void Awake()
    {
        Instance = this;

        GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<HealthSystem>().OnDead += PlayerDefeat;
        GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<HealthSystem>().OnDead += PlayerWin;

        StartCoroutine(GetMercenaryCostCoroutine());
    }

    private void Update()
    {
        _stageTime += Time.deltaTime;
    }

    private void PlayerWin(GameObject killer)
    {
        if (!_isStageEnd)
        {
            Instantiate(_stageResultUIPrefab, _stageResultUIParent).GetComponent<StageResultUIController>().SetStageResultUI(_stageData.StageLevel, _stageTime, _stageData.StageWinGold, true);
            DeckManager.Gold += _stageData.StageWinGold;
            if (!_stageData.IsSubStage) StageSelectManager.LastClearStageLevel = _stageData.StageLevel;

            for (int i = 0; i < _stageData.RewardUnits.Length; i++)
            {
                for (int j = 0; j < UnitManager.Instance.UnitDatas.Length; j++)
                {
                    if (_stageData.RewardUnits[i] == UnitManager.Instance.UnitDatas[j])
                    {
                        UnitManager.Instance.UnitDatas[j].HasUnit = true;
                    }
                }
            }

            _isStageEnd = true;
        }
    }

    private void PlayerDefeat(GameObject killer)
    {
        if (!_isStageEnd)
        {
            Instantiate(_stageResultUIPrefab, _stageResultUIParent).GetComponent<StageResultUIController>().SetStageResultUI(_stageData.StageLevel, _stageTime, _stageData.StageDefeatGold, false);
            DeckManager.Gold += _stageData.StageDefeatGold;

            _isStageEnd=true;
        }
    }

    private IEnumerator GetMercenaryCostCoroutine()
    {
        while (!_isStageEnd)
        {
            MercenaryCoin += _getMercenaryCoinValuePerSecond;

            yield return new WaitForSeconds(1);
        }

        yield break;
    }
}
