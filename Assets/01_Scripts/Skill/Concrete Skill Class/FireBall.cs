using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _destroyTime;

    private void Awake()
    {
        Collider[] enemys = Physics.OverlapSphere(transform.position, 5, 1 << LayerMask.NameToLayer("Enemy"));

        foreach(Collider enemy in enemys)
        {
            if (enemy.GetComponent<HealthSystem>() != null)
            {
                enemy.GetComponent<HealthSystem>().TakeDamage(_damage, gameObject);
            }
        }

        Destroy(gameObject, _destroyTime);
    }
}
