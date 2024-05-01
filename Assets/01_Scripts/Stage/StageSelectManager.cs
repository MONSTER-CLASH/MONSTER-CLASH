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
}
