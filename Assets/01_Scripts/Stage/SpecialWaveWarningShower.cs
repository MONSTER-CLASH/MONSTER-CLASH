using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWaveWarningShower : MonoBehaviour
{
    public static SpecialWaveWarningShower Instance;

    private bool _isShowedWarning = false;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowWarning()
    {
        if (!_isShowedWarning)
        {
            Debug.Log("Special Wave!");

            _isShowedWarning = true;
        }
    }
}
