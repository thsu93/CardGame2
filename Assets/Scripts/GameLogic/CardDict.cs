using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Intended to manage transition from database to prefabs
/// 
/// Likely replaced code, will revisit later
/// 
/// TODO: A lot of work needed here if to be used. Database likely needed.
/// 
/// </summary>
public class CardDict : MonoBehaviour
{
    Dictionary<string, GameObject> cardMap = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> comboMap = new Dictionary<string, GameObject>();

    void Awake()
    {
        cardMap.Add("000001", (GameObject)Resources.Load("SlashCard"));
        cardMap.Add("000002", (GameObject)Resources.Load("StabCard"));
        cardMap.Add("000003", (GameObject)Resources.Load("StrikeCard"));
        cardMap.Add("000004", (GameObject)Resources.Load("AttackCard"));
        cardMap.Add("000005", (GameObject)Resources.Load("DefendCard"));
        cardMap.Add("000006", (GameObject)Resources.Load("SpellCard"));


        comboMap.Add("000001000002000003", (GameObject)Resources.Load("BladeDanceCombo"));
    }


    public Card GetCard(string name)
    {
        //should not ever error
        return cardMap[name].GetComponent<Card>();
    }

    public bool isACombo(string cardIDs)
    {
        return comboMap.ContainsKey(cardIDs);
    }

    public Card GetComboCard(string cardIDs)
    {
        if (comboMap[cardIDs] != null)
        {
            return comboMap[cardIDs].GetComponent<Card>();
        }
        else
            return null;
    }

}