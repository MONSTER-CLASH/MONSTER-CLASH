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
        if (state != State.Drop || other.CompareTag("GameController"))
            return;

        if (other.gameObject.CompareTag("SpawnZone") && StageDeckController.Instance.mercenaryCoin > DeckManager.EquipCardDatas[cardIndex].SpawnCost)
        {
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
}