using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private int _stageClearRewardGold;
    [SerializeField] private GameObject _stageResultUIPrefab;
    [SerializeField] private Transform _stageResultUIParent;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("PlayerBase").GetComponent<HealthSystem>().OnDead += PlayerDefeat;
        GameObject.FindGameObjectWithTag("EnemyBase").GetComponent<HealthSystem>().OnDead += PlayerWin;
    }

    private void PlayerWin(GameObject killer)
    {
        Instantiate(_stageResultUIPrefab, _stageResultUIParent);
        DeckManager.Gold += _stageClearRewardGold;
    }

    private void PlayerDefeat(GameObject killer)
    {
        Instantiate(_stageResultUIPrefab, _stageResultUIParent);
    }
}
