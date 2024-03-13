using UnityEngine;

public class AttackableProjectile : AttackSystem
{
    private GameObject _attacker;
    private GameObject _target;
    private float _damage;
    private bool _isTargeted;

    private void FixedUpdate()
    {
        if (_target != null)
        {
            transform.LookAt(_target.transform.position);
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
        _isTargeted = true;

        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_target != null && other.gameObject == _target)
        {
            SendDamage(_target, _damage, _attacker);
            Destroy(gameObject);
        }
    }
}
