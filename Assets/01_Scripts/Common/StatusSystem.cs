using System.Collections;
using UnityEngine;

public class StatusSystem : MonoBehaviour
{
    [Header("Status")]
    public string Name;
    public float MaxHealth;
    public float CurrentHealth;

    public float AttackDamage
    {
        get
        {
            if (GetComponent<BuffSystem>() != null && GetComponent<BuffSystem>().ContainsBuff<AttackDamageIncreaseBuff>())
            {
                return GetComponent<BuffSystem>().GetBuff<AttackDamageIncreaseBuff>().GetInDecreaseBuffValue(_attackDamage);
            }
            else
            {
                return _attackDamage;
            }
        }
    }
    protected float _attackDamage;

    public float AttackSpeed;
    public float AttackRange;
}
