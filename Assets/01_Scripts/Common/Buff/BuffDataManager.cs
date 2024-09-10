using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDataManager : MonoBehaviour
{
    public static BuffDataManager Instance;

    [Header("Negative Buff")]
    public BuffData StunBuffData;
    public BuffData MoveSpeedDecreaseBuffData;

    [Header("Positive Buff")]
    public BuffData AttackDamageIncreaseBuffData;

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
