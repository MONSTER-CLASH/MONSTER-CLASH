using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageDeckController : MonoBehaviour
{
    public Transform[] SpawnBases;
    public TMP_Text[] SpawnCoolTimeText;
    public TMP_Text MerceneryCoinText;

    [SerializeField] private GameObject[] SpawnArea = new GameObject[6];

    public float[] coolTime;

    public float mercenaryCoin;
    public float mercenartCoinPerSecond;


    public static StageDeckController Instance = null;

    private void Awake()
    {
        Instance = this;

        SpawnDeck();
    }

    private void Update()
    {
        GetMerceneryCoin();
        UpdateCoolTimeText();
        SetMerceneryCoin();
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

    private void GetMerceneryCoin()
    {
        mercenaryCoin += (Time.deltaTime * mercenartCoinPerSecond);
    }

    public void UseMerceneryCoin(int cost)
    {
        mercenaryCoin -= cost;
    }

    private void SetMerceneryCoin()
    {
        MerceneryCoinText.text = ((int)mercenaryCoin).ToString();
    }

    public void ShowSpawnArea(int index)
    {
        if(DeckManager.EquipCardDatas[index].CardType == CardType.Skill)
        {
            foreach (GameObject area in SpawnArea)
            {
                area.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnArea[i].SetActive(true);
            }
        }
    }

    public void HideSpawnArea()
    {
        foreach (GameObject area in SpawnArea)
        {
            area.SetActive(false);
        }
    }
}
