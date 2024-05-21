using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public static StageData StageData;
    public int MercenaryCoin;

    [Header("Result UI")]
    [SerializeField] private GameObject _stageResultUIPrefab;
    [SerializeField] private Transform _stageResultUIParent;

    [Space()]
    [SerializeField] private int _getMercenaryCoinValuePerSecond; // 초당 용병주화 생성량

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
            Instantiate(_stageResultUIPrefab, _stageResultUIParent).GetComponent<StageResultUIController>().SetStageResultUI(StageData.StageLevel, _stageTime, StageData.StageWinGold, true);
            DeckManager.Gold += StageData.StageWinGold;
            if (!StageData.IsSubStage) StageDataManager.LastClearStageLevel = StageData.StageLevel;

            for (int i = 0; i < StageData.RewardUnits.Length; i++)
            {
                for (int j = 0; j < UnitManager.Instance.UnitDatas.Length; j++)
                {
                    if (StageData.RewardUnits[i] == UnitManager.Instance.UnitDatas[j])
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
            Instantiate(_stageResultUIPrefab, _stageResultUIParent).GetComponent<StageResultUIController>().SetStageResultUI(StageData.StageLevel, _stageTime, StageData.StageDefeatGold, false);
            DeckManager.Gold += StageData.StageDefeatGold;

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
