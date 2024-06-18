using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageDataManager : MonoBehaviour
{
    public static StageDataManager Instance;
    public static int LastClearStageLevel;

    [SerializeField] private StageData[] _mainStageDatas;
    [SerializeField] private StageData[] _subStageDatas;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SoundManager.Instance.SoundPlay(SoundManager.Instance.StageSelectSceneBGM, SoundType.BGM);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartStage(GetNextMainStageData());
        }
    }

    /// <summary>
    /// 다음 메인 스테이지 정보 반환 메서드
    /// </summary>
    public StageData GetNextMainStageData()
    {
        return _mainStageDatas.Length > LastClearStageLevel ? _mainStageDatas[LastClearStageLevel] : null;
    }

    /// <summary>
    /// StageData를 통한 스테이지 시작 메서드
    /// </summary>
    public void StartStage(StageData stageData)
    {
        DeckManager.Instance.SetEquipDeck();
        StageManager.StageData = stageData;
        SceneManager.LoadScene("Main Stage 1");
    }

    public void StartNextMainStage()
    {
        StartStage(GetNextMainStageData());
    }

    public StageData[] GetSubStageDatas(int getStageCount)
    {
        List<StageData> stageDatas = new List<StageData>();
        int stageCount = 0;

        for (int i=0; i<_subStageDatas.Length; i++)
        {
            if (_subStageDatas[i].RequiredMinMainStage >= LastClearStageLevel && 
                _subStageDatas[i].RequiredMaxMainStage <= LastClearStageLevel &&
                stageCount < getStageCount)
            {
                stageDatas.Add(_subStageDatas[i]);
                stageCount++;
            }
        }

        if (stageDatas.Count < getStageCount) Debug.LogWarning("Not enough Sub Stage");

        return stageDatas.ToArray();
    }
}
