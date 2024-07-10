using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public enum State
    {
        Idle,
        Drop,
    }

    public int cardIndex;

    public bool isSpawn;
    private State state;

    public UnityEvent OnRecycle;
    public UnityEvent OnSpawn;

    private void Update()
    {
        FixPosition();
    }

    public void Drop()
    {
        state = State.Drop;
    }

    public void Idle()
    {
        state = State.Idle;
    }

    public void Cancle()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        interactable.interactionManager.CancelInteractableSelection((IXRSelectInteractable)interactable);
    }

    public void Throw()
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0f, 300f, 300f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController")) return;
        if (state != State.Drop || StageDeckController.Instance.mercenaryCoin < DeckManager.EquipCardDatas[cardIndex].SpawnCost)
        {
            Recycle();
            return;
        }


        if (other.gameObject.CompareTag("SpawnZone"))
        {
            Debug.Log("이거 맞고" + other.name + "스폰존");
            Spawn();
        }
        else if (other.gameObject.CompareTag("SkillSpawnZone") && gameObject.CompareTag("SkillModel"))
        {
            Debug.Log("이거 맞고" + other.name + "스킬스폰존");
            Spawn();
        }
        else
        {
            Recycle();
        }
    }

    public void SpawnPrefab()
    {
        Instantiate(DeckManager.EquipCardDatas[cardIndex].CardPrefab, transform.position, Quaternion.identity);
    }

    public void Spawn()
    {
        OnSpawn?.Invoke();
    }

    public void Recycle()
    {
        OnRecycle?.Invoke();
    }

    private void FixPosition()
    {
        if (state != State.Drop)
        {
            gameObject.transform.position = StageDeckController.Instance.SpawnBases[cardIndex].position;
        }
    }

    public void Interatable()
    {
        StartCoroutine("InteractableCoolTime");
    }

    IEnumerator InteractableCoolTime()
    {
        var xrGrabInteractable = GetComponent<XRGrabInteractable>();
        xrGrabInteractable.enabled = false;
        StageDeckController.Instance.coolTime[cardIndex] = DeckManager.EquipCardDatas[cardIndex].SpawnCoolTime;
        StageDeckController.Instance.UseMerceneryCoin(DeckManager.EquipCardDatas[cardIndex].SpawnCost);
        yield return new WaitForSeconds(DeckManager.EquipCardDatas[cardIndex].SpawnCoolTime);
        xrGrabInteractable.enabled = true;
    }

    public void SelectModel()
    {
        StageDeckController.Instance.ShowSpawnArea(cardIndex);
    }

    public void UnSelectModel()
    {
        StageDeckController.Instance.HideSpawnArea();
    }
}