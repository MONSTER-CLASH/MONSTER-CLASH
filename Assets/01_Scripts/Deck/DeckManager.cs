using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private Text _currentGoldText;

    [SerializeField] private Transform _haveUnitParent;
    [SerializeField] private GameObject _haveUnitInfoItem;

    private void Awake()
    {
        
    }
}
