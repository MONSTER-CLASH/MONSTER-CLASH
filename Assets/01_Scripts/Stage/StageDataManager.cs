using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageDataManager : MonoBehaviour
{
    public static StageDataManager Instance;
    public static int LastClearStageLevel;
    public static StageData _playingStageData;

    [SerializeField] private StageData[] _mainStageDatas;
    [SerializeField] private StageData[] _subStageDatas;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 다음 메인 스테이지 정보 반환 메서드
    /// </summary>
    public StageData GetNextMainStageData()
    {
        return _mainStageDatas[LastClearStageLevel];
    }

    /// <summary>
    /// StageData를 통한 스테이지 시작 메서드
    /// </summary>
    public void StartStage(StageData stageData)
    {
        DeckManager.Instance.SetEquipDeck();
        _playingStageData = stageData;
        SceneManager.LoadScene(stageData.StageName);
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
