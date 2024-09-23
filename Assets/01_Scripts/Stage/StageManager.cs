using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public static StageData StageData;
    public int MercenaryCoin;

    public bool IsStageEnd { get => _isStageEnd; }

    [Header("Result UI")]
    [SerializeField] private GameObject _stageResultUIPrefab;
    [SerializeField] private Transform _stageWinResultUIParent;
    [SerializeField] private Transform _stageDefeatResultUIParent;

    [Space()]
    [SerializeField] private GameObject _leftRayController;
    [SerializeField] private GameObject _rightRayController;
    [SerializeField] private GameObject _leftDirectController;
    [SerializeField] private GameObject _rightDirectController;

    [SerializeField] private GameObject deckObject;

    private float _stageTime;
    private bool _isStageEnd;

    private void Awake()
    {
        Instance = this;

        GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<HealthSystem>().OnDead += PlayerDefeat;
        GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<HealthSystem>().OnDead += PlayerWin;
    }

    private void Start()
    {
        SoundManager.Instance.SoundPlay(SoundManager.Instance.StageSceneBGM, SoundType.BGM);
        StartCoroutine(FadeInOutManager.Instance.FadeOut(null));
    }

    private void Update()
    {
        _stageTime += Time.deltaTime;
    }

    private void PlayerWin(GameObject killer)
    {
        if (!_isStageEnd)
        {
            //_leftDirectController.SetActive(false);
            //_rightDirectController.SetActive(false);
            _leftRayController.SetActive(true);
            _rightRayController.SetActive(true);
            //deckObject.GetComponent<BoxCollider>().isTrigger = false;

            Instantiate(_stageResultUIPrefab, _stageWinResultUIParent).GetComponent<StageResultUIController>().SetStageResultUI(StageData, _stageTime, true);
            DeckManager.Gold += StageData.StageWinGold;
            if (!StageData.IsSubStage) StageDataManager.LastClearStageLevel = StageData.StageLevel;

            for (int i = 0; i < StageData.RewardUnits.Length; i++)
            {
                for (int j = 0; j < CardManager.Instance.CardDatas.Length; j++)
                {
                    if (StageData.RewardUnits[i] == CardManager.Instance.CardDatas[j])
                    {
                        CardManager.Instance.CardDatas[j].HaveCard = true;
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
            //_leftDirectController.SetActive(false);
            //_rightDirectController.SetActive(false);
            _leftRayController.SetActive(true);
            _rightRayController.SetActive(true);
            //deckObject.GetComponent<BoxCollider>().isTrigger = false;

            Instantiate(_stageResultUIPrefab, _stageDefeatResultUIParent).GetComponent<StageResultUIController>().SetStageResultUI(StageData, _stageTime, false);
            DeckManager.Gold += StageData.StageDefeatGold;

            _isStageEnd=true;
        }
    }
}
