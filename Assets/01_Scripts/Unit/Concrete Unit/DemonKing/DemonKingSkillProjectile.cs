using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonKingSkillProjectile : MonoBehaviour
{
    private GameObject _attacker;
    private string _enemyLayer;
    private float _damage;
    private float _speed;

    private void Awake()
    {
        Destroy(gameObject, 0.75f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void SetDemonKingSkillData(GameObject attacker, string enemyLayer, float damage, float speed)
    {
        _attacker = attacker;
        _enemyLayer = enemyLayer;
        _damage = damage;
        _speed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthSystem>() && other.gameObject.layer == LayerMask.NameToLayer(_enemyLayer))
        {
            Collider hit = other;
            hit.GetComponent<HealthSystem>().TakeDamage(_damage, _attacker);
            VFXManager.Instance.InstantiateUnitHitVFX(other.transform);
        }
    }
}
