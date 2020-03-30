using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDict : MonoBehaviour
{
    Dictionary<string, GameObject> cardMap = new Dictionary<string, GameObject>();
    Dictionary<string[], GameObject> comboMap = new Dictionary<string[], GameObject>();


    void Awake()
    {
        cardMap.Add("Slash", (GameObject)Resources.Load("SlashCard"));
        cardMap.Add("Stab", (GameObject)Resources.Load("StabCard"));
        cardMap.Add("Strike", (GameObject)Resources.Load("StrikeCard"));
        cardMap.Add("Attack", (GameObject)Resources.Load("AttackCard"));
        cardMap.Add("Defend", (GameObject)Resources.Load("DefendCard"));
        cardMap.Add("Spell", (GameObject)Resources.Load("SpellCard"));

        comboMap.Add(new string[3]{"Slash", "Stab", "Strike"}, (GameObject)Resources.Load("BladeDanceCombo"));
    }


    public Card GetCard(string name)
    {
        //should not ever error
        return cardMap[name].GetComponent<Card>();
    }

    public bool isACombo(string[] cards)
    {
        return comboMap.ContainsKey(cards);
    }

    public Card GetComboCard(string[] names)
    {
        if (comboMap[names] != null)
        {
            return comboMap[names].GetComponent<Card>();
        }
        else
            return null;
    }

}
