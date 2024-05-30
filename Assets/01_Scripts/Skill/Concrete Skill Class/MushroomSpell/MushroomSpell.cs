using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpell : MonoBehaviour
{
    [SerializeField] private MushroomSpellCardData _mushroomSpellCardData;
    private GameObject _mushroomPrefab;
    private float _tickTime;
    private float _destoryTime;

    private void Awake()
    {
        _mushroomPrefab = _mushroomSpellCardData.MushroomPrefab;
        _tickTime = _mushroomSpellCardData.TickTime;
        _destoryTime = _mushroomSpellCardData.DurationTime;

        StartCoroutine(MushroomSpellCoroutine());
        Destroy(gameObject, _destoryTime);
    }

    private IEnumerator MushroomSpellCoroutine()
    {
        while (true)
        {
            Vector3 spawnPos = transform.position + (Random.insideUnitSphere * 2.5f);
            Instantiate(_mushroomPrefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(_tickTime);
        }
    }
}
