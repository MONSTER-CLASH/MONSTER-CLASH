using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealArea : MonoBehaviour
{
    [SerializeField] private HealAreaCardData _healAreaCardData;
    private float _heal;
    private float _tickTime;
    private float _destoryTime;

    private void Awake()
    {
        SoundManager.Instance.SoundPlay(SoundManager.Instance.HealAreaSFX);

        _heal = _healAreaCardData.Heal;
        _tickTime = _healAreaCardData.TickTime;
        _destoryTime = _healAreaCardData.DurationTime;

        StartCoroutine(HealAreaCoroutine());
        Destroy(gameObject, _destoryTime);
    }

    private IEnumerator HealAreaCoroutine()
    {
        while (true)
        {
            Collider[] players = Physics.OverlapSphere(transform.position, 2.5f, 1 << LayerMask.NameToLayer("Player"));

            foreach (Collider player in players)
            {
                if (player.GetComponent<HealthSystem>() != null)
                {
                    player.GetComponent<HealthSystem>().TakeHeal(_heal, gameObject);
                }
            }

            yield return new WaitForSeconds(_tickTime);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(0.5f, 0, 0, 0.15f);
    //    Gizmos.DrawSphere(transform.position, 2.5f);
    //}
}
