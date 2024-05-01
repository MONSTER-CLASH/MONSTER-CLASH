using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public static StageSelectManager Instance;
    public static int LastClearStageLevel;

    [SerializeField] private StageData[] _mainStageDatas;
    [SerializeField] private StageData[] _subStageDatas;

    private void Awake()
    {
        Instance = this;
    }

    public StageData GetNextMainStageData()
    {
        return _mainStageDatas[LastClearStageLevel];
    }

    public void StartStage(StageData stageData)
    {
        SceneManager.LoadScene(stageData.StageName);
    }

    public void StartStage(string stageName)
    {
        SceneManager.LoadScene(stageName);
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
                getStageCount < stageCount)
            {
                stageDatas.Add(_subStageDatas[i]);
                stageCount++;
            }
        }

        if (stageDatas.Count < getStageCount) Debug.LogWarning("Not enough Sub Stage");

        return stageDatas.ToArray();
    }
}
