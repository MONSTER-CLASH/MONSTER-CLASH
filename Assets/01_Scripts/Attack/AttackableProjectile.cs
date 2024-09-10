using UnityEngine;

public class AttackableProjectile : AttackSystem
{
    private GameObject _attacker;
    private GameObject _target;
    private float _damage;
    private float _speed;
    private bool _isTargeted;

    private void FixedUpdate()
    {
        if (_target != null)
        {
            transform.LookAt(_target.transform.position);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        else if (_isTargeted)
        {
            Destroy(gameObject);
        }
        
    }

    public void SetProjectileData(GameObject attacker, GameObject target, float damage, float speed)
    {
        _attacker = attacker;
        _target = target;
        _damage = damage;
        _speed = speed;
        _isTargeted = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_target != null && other.gameObject == _target)
        {
            VFXManager.Instance.InstantiateUnitHitVFX(other.transform);
            SendDamage(_target, _damage, _attacker);
            Destroy(gameObject);
        }
    }
}
