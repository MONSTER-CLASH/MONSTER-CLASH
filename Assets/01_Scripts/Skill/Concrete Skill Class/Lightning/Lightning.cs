using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private LightningCardData _lightningCardData;
    [SerializeField] private ParticleSystem _lightningParticleSystem;
    [SerializeField] private ParticleSystem _explosionParticleSystem;
    private float _damage;
    private float _destroyTime;

    private void Awake()
    {
        _damage = _lightningCardData.Damage;
        _destroyTime = _lightningCardData.DestroyTime;

        StartCoroutine(LightningCoroutine());

        Destroy(gameObject, _destroyTime);
    }

    private IEnumerator LightningCoroutine()
    {
        float explosionTime = _lightningParticleSystem.transform.localPosition.y / _lightningParticleSystem.main.startSpeed.constant;
        yield return new WaitForSeconds(explosionTime);
        
        _explosionParticleSystem.Play();

        Collider[] enemys = Physics.OverlapSphere(transform.position, 2, 1 << LayerMask.NameToLayer("Enemy"));

        foreach (Collider enemy in enemys)
        {
            if (enemy.GetComponent<HealthSystem>() != null)
            {
                enemy.GetComponent<HealthSystem>().TakeDamage(_damage, gameObject);
            }
        }

        yield break;
    }
}
