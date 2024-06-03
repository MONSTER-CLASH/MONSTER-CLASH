using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageDeckController : MonoBehaviour
{
    public Transform[] SpawnBases;
    public TMP_Text[] SpawnCoolTimeText;
    
    public float[] coolTime;

    public int mercenaryCoin;


    public static StageDeckController Instance = null;

    private void Awake()
    {
        Instance = this;

        SpawnDeck();
    }

    private void Update()
    {
        UpdateCoolTimeText();
    }

    private void SpawnDeck()
    {
        for (int i = 0; i < DeckManager.EquipCardDatas.Length; i++)
        {
            if (DeckManager.EquipCardDatas[i] == null) continue;
            GameObject SpawnMesh = Instantiate(DeckManager.EquipCardDatas[i].CardModel, transform.position, Quaternion.identity);

            SpawnMesh.GetComponent<Ball>().cardIndex = i;
        }
    }

    public void UpdateCoolTimeText()
    {
        for (int i = 0; i < DeckManager.EquipCardDatas.Length; i++)
        {
            if(coolTime[i] > 0)
            {
                SpawnCoolTimeText[i].enabled = true;
                SpawnCoolTimeText[i].text = ((int)coolTime[i]).ToString();
                coolTime[i] -= Time.deltaTime;
            }
            else
            {
                SpawnCoolTimeText[i].enabled = false;
            }
        }
    }
}
