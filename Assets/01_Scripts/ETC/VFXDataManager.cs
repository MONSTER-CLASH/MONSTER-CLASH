using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXDataManager : MonoBehaviour
{
    public static VFXDataManager Instance;

    [Header("Common VFX Prefabs")]
    public GameObject UnitHitVFX;
    public GameObject UnitDieVFX;
    public GameObject StageClearVFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
