using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private LightningCardData _lightningCardData;
    [SerializeField] private float _attackRange;
    private float _damage;
    private float _destroyTime;

    private void Awake()
    {
        SoundManager.Instance.SoundPlay(SoundManager.Instance.LightningSFX);

        _damage = _lightningCardData.Damage;
        _destroyTime = _lightningCardData.DestroyTime;

        Collider[] enemys = Physics.OverlapSphere(transform.position, _attackRange, 1 << LayerMask.NameToLayer("Enemy"));

        foreach (Collider enemy in enemys)
        {
            if (enemy.GetComponent<HealthSystem>() != null)
            {
                enemy.GetComponent<HealthSystem>().TakeDamage(_damage, gameObject);
            }
        }

        Destroy(gameObject, _destroyTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 0.75f, 0.25f);
        Gizmos.DrawSphere(transform.position, _attackRange);
    }
}
