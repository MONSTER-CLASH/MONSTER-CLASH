using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestBulletinBoardManager : MonoBehaviour
{
    [SerializeField] private RequestItem _mainRequestItem;
    [SerializeField] private RequestItem[] _subRequestItems = new RequestItem[2];

    private void Awake()
    {
        UpdateRequestItem();
    }

    private void UpdateRequestItem()
    {
        if (StageDataManager.Instance.GetNextMainStageData() != null)
        {
            _mainRequestItem.UpdateRequestInfo(StageDataManager.Instance.GetNextMainStageData());
        }
        else
        {
            _mainRequestItem.gameObject.SetActive(false);
        }

        StageData[] subStageDatas = StageDataManager.Instance.GetSubStageDatas(2);

        for (int i=0; i<2; i++)
        {
            if (i < subStageDatas.Length)
                _subRequestItems[i].UpdateRequestInfo(subStageDatas[i]);
            else
                _subRequestItems[i].gameObject.SetActive(false);
        }
    }
}
