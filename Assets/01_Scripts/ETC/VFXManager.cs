using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static VFXManager Instance;

    [Header("Common VFX Prefabs")]
    public GameObject UnitHitVFX;
    public GameObject UnitDieVFX;

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

    public void InstantiateUnitHitVFX(Transform hittedUnit, GameObject vfx = null)
    {
        GameObject go = null;

        if (vfx) go = Instantiate(vfx, hittedUnit);
        else go = Instantiate(UnitHitVFX, hittedUnit);

        go.transform.localPosition = Vector3.zero;
    }
}
